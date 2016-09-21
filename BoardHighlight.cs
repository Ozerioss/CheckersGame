using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BoardHighlights : MonoBehaviour {
	public static BoardHighlights Instance { get; set; }
    public GameObject highlightPrefab;
    private List<GameObject> highlights;
    private void Start()
    {
        Instance = this;
        highlights = new List<GameObject>();
    }
    private GameObject GetHighlightObject() // method to get the highlighted object
    {
        GameObject go  = highlights.Find(g => !g.activeSelf);  // RESEARCH THIS LINE
        //GameObject go = new GameObject();
        if(go == null)
        {
            go = Instantiate(highlightPrefab);
            highlights.Add(go);
       }
        return go;
    }
    public void HighlightAllowedMoves(bool[,] moves) // Allowed moves still has to be coded
    {
        for(int i=0; i<8;i++)
        {
            for(int j=0; j<8;j++)
            {
                if(moves[i,j])
                {
                    GameObject go = GetHighlightObject();
                    go.SetActive(true) ;
                    go.transform.position = new Vector3 (i + 0.5f, 0, j + 0.5f);
                }
            }
        }
    }
    
    public void HideHighlights() // Method to remove the highlight
    {
        foreach(GameObject go in highlights)
        {
            go.SetActive(false);
        }
    }
}
