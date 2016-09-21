using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BoardManager : MonoBehaviour {
    public static BoardManager Instance { get; set; }
    private bool[,] allowedMoves { get; set; }
    public Checkers[,] CheckerMan { get; set; }  // multi dimentional array
    private Checkers selectedCheckerMan;
    private const float TILE_SIZE = 1.0f; // 1 metre par case 
    private const float TILE_OFFSET = 0.5f; // Offset pour être au centre 
    private int selectionX = -1;  // On utilisera ces variables par la suite pour avoir un glowing effect sur les cases 
    private int selectionY = -1;
    public List<GameObject> checkersPrefab;
    public List<GameObject> activeCheckersPiece;
    private Material previousMat;
    public Material selectedMat;
    public bool isWhiteTurn = true;
    private void Start()
    {
        //SpawnCheckersPiece(0,GetTileCenter(1,1));
        Instance = this;
        SpawnAllCheckersPieces();
    }
    private void Update()
    {
        UpdateSelection();
        DrawChessboard();
        if(Input.GetMouseButtonDown(0))
        {
            if(selectionX >=0 && selectionY >=0)
            {
                if(selectedCheckerMan == null)
                {
                    //Select the checker piece6 method to insert here
                    SelectCheckerPiece(selectionX, selectionY);
                }
                else // if it is selected
                {
                    // Method to move him
                    MoveCheckerPiece(selectionX, selectionY);
                }
            }
        }
    }
    private void SelectCheckerPiece(int x, int y)
    {
        if(CheckerMan[x,y] == null)
        {
            return;
        }
        if(CheckerMan[x,y].isWhite != isWhiteTurn)
        {
            return;
        }
        bool hasAtleastOneMove = false;
        allowedMoves = CheckerMan[x, y].PossibleMove();  // KOULCHI
        #region to select the piece only if it has one move avaialable
        for (int i =0 ; i < 8 ; i++)
        {
            for(int j=0; j < 8; j++)
            {
                if(allowedMoves[i,j])
                {
                    hasAtleastOneMove = true;
                }
            }
        }
        if (!hasAtleastOneMove)
        {
            return;
        }
        #endregion
        selectedCheckerMan = CheckerMan[x, y];
        // Doesnt work for now 
        #region Avoir un feedback quand on sélectionne une pièce 
        previousMat = selectedCheckerMan.GetComponent<MeshRenderer>().material;
        selectedMat.mainTexture = previousMat.mainTexture;
        selectedCheckerMan.GetComponent<MeshRenderer>().material = selectedMat;
        #endregion
        BoardHighlights.Instance.HighlightAllowedMoves(allowedMoves);
        
    }
    private void MoveCheckerPiece(int x, int y) // Moves the checker piece without restriction
    {
        if (allowedMoves[x, y])  // array of booleans 
        {
            Checkers c = CheckerMan[x, y]; // DETRUIRE  FIX
            #region Taking a piece
            Debug.Log("if allowedMoves");
            // We have to destroy the pieces here !!! CODE WRONG HERE NEEDS FIXING
                //if (c != null && c.isWhite != isWhiteTurn)
                //{
                //    Debug.Log("juste avant de détruire");
                //    // Capture a piece
                //    // Debug.Log(selectedCheckerMan.CurrentX.ToString() + " " + selectedCheckerMan.CurrentY.ToString() + " " + x.ToString() + " " + y.ToString());
                //    //c = CheckerMan[x + 1, y + 1];
                //    activeCheckersPiece.Remove(c.gameObject);
                //    Destroy(c.gameObject);
                //}
            #endregion
                if (y == 0)
                {
                    Debug.Log("White king spawn");
                    activeCheckersPiece.Remove(selectedCheckerMan.gameObject);
                    Destroy(selectedCheckerMan.gameObject);
                    SpawnCheckersPiece(3, x, y);
                    selectedCheckerMan = CheckerMan[x, y];
                }
                if (y == 7)
                {
                    Debug.Log("Black king spawn");
                    activeCheckersPiece.Remove(selectedCheckerMan.gameObject);
                    Destroy(selectedCheckerMan.gameObject);
                    SpawnCheckersPiece(2, x, y);
                    selectedCheckerMan = CheckerMan[x, y];
                }
            
            Debug.Log("x = " + x + "y = " + y);
            CheckerMan[selectedCheckerMan.CurrentX, selectedCheckerMan.CurrentY] = null;
            selectedCheckerMan.transform.position = GetTileCenter(x, y);
            selectedCheckerMan.SetPosition(x, y);
            CheckerMan[x, y] = selectedCheckerMan;
            isWhiteTurn = !isWhiteTurn;
        }
        selectedCheckerMan.GetComponent<MeshRenderer>().material = previousMat;
        BoardHighlights.Instance.HideHighlights();
        selectedCheckerMan = null;
    }  
    // This was used early on in the project, to have a basic board
    private void DrawChessboard()
    {
        Vector3 widthLine = Vector3.right * 8;
        Vector3 heightLine = Vector3.forward * 8;
        for(int i=0; i<=8; i++) 
        {
            Vector3 start = Vector3.forward * i;
            Debug.DrawLine(start, start + widthLine);
            start = Vector3.right * i;
            Debug.DrawLine(start, start + heightLine);
        }
        if (selectionX >= 0 && selectionY >= 0)
        {
            // This draws a cross whenever we hover with the mouse over a tile ( case ) 
            Debug.DrawLine(Vector3.forward * selectionY + Vector3.right * selectionX, 
                Vector3.forward * (selectionY + 1) + Vector3.right * (selectionX + 1));
            Debug.DrawLine(Vector3.forward * (selectionY + 1) + Vector3.right * selectionX,
                Vector3.forward * selectionY + Vector3.right * (selectionX + 1));
        }
    }
    private void UpdateSelection()
    {
        if (!Camera.main) // Pour éviter les erreurs 
        {
            return;
        }
        RaycastHit hit; // On utilisera pour les glowing effects 
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit, 25.0f, LayerMask.GetMask("ChessPlane")))
        {
            selectionX = (int)hit.point.x;
            selectionY = (int)hit.point.z;
        }
        else  // Reset pour éviter de rentrer dans le IF statement du DrawChessboard() 
        {
            selectionX = -1;
            selectionY = -1;
        }
            
    }
    // Used to center our pieces 
    private Vector3 GetTileCenter(int x, int y)
    {
        Vector3 origin = Vector3.zero;
        origin.x += (TILE_SIZE * x) + TILE_OFFSET;
        origin.z += (TILE_SIZE * y) + TILE_OFFSET;
        return origin;
    }
    private void SpawnCheckersPiece(int index, int x, int y)
    {
        GameObject go = Instantiate(checkersPrefab[index], GetTileCenter(x,y) , Quaternion.identity) as GameObject;
        go.transform.SetParent(transform);
        CheckerMan[x, y] = go.GetComponent<Checkers>();
        CheckerMan[x, y].SetPosition(x, y);
        activeCheckersPiece.Add(go);
    }
    // Method to spawn all checkers piece in the correct spot
    private void SpawnAllCheckersPieces()
    {
        activeCheckersPiece = new List<GameObject>();
        CheckerMan = new Checkers[8,8];
        // Spawn whites
        #region Spawning white checkers
        // First white row
        for (int i=0; i<=7; i+=2)
        {
            SpawnCheckersPiece(0,i, 0);
            
        }
        // Second row white checkers
        for(int i=0; i<=7; i+=2)
        {
            SpawnCheckersPiece(0, i + 1, 1);
        }
        // Last row white checkers
        for(int i=0; i<=7; i+=2)
        {
            SpawnCheckersPiece(0, i , 2);
        }
        #endregion
        // Spawning blacks
        #region Spawning black checkers
        // First black row
        for (int i = 0; i <= 7; i += 2)
        {
            SpawnCheckersPiece(1, i, 6);
        }
        // Second row black checkers
        for (int i = 0; i <= 7; i += 2)
        {
            SpawnCheckersPiece(1, i + 1, 7);
        }
        // Last row black checkers
        for (int i = 0; i <= 7; i += 2)
        {
            SpawnCheckersPiece(1, i + 1, 5);
        }
        #endregion 
    }
}
