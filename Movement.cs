using UnityEngine;
using System.Collections;
public class Movement : Checkers
{
    public override bool[,] PossibleMove()
    {
        Checkers c;
        Checkers c2;
       // BoardManager b = AddComponentMenu(b);
        
       
        //Checkers c2;
        bool[,] r = new bool[8, 8];
        //int XD, YD; // Variables pour stocker les coordonnées de la pièce à détruire
        #region White Team
        if (isWhite)
        {
            // Diagonal Left
            if (CurrentX != 7 && CurrentY != 0)
            {
                c = BoardManager.Instance.CheckerMan[CurrentX + 1, CurrentY - 1];
                if (c == null)
                {
                    //#region console stuff diag left
                    //Debug.Log("CurrentX " + CurrentX.ToString());
                    //Debug.Log("CurrentY " + CurrentY.ToString());  
                    //#endregion
                    r[CurrentX + 1, CurrentY - 1] = true;
                }
                else if (!c.isWhite)
                {   //If there is a piece THAT WE CAN TAKE
                    if (CurrentX < 6 && CurrentY > 1)
                    {
                        c2 = BoardManager.Instance.CheckerMan[CurrentX + 2, CurrentY - 2];  // Pour ne pas sauter sur une pièce déjà présente
                        if (c2 == null)
                        {
                            r[CurrentX + 2, CurrentY - 2] = true;
                        }
                        
                    }
                }
            }
            //Diagonal Right
            if (CurrentX != 0 && CurrentY != 0)
            {
                c = BoardManager.Instance.CheckerMan[CurrentX - 1, CurrentY - 1];
                //#region console stuff white diag right 
                //Debug.Log("CurrentX " + CurrentX.ToString());
                //Debug.Log("CurrentY " + CurrentY.ToString());  
                //#endregion
                if (c == null)
                {
                    r[CurrentX - 1, CurrentY - 1] = true;
                }
                else if (!c.isWhite)
                {
                    if (CurrentX > 1 && CurrentY > 1)
                    {
                        c2 = BoardManager.Instance.CheckerMan[CurrentX - 2, CurrentY - 2];
                        if (c2 == null)
                        {
                            r[CurrentX - 2, CurrentY - 2] = true;
                        }
                    }
                }
                
            }
        }  // Done till now
        #endregion
        #region  Black Team
        else
        {
            // Diagonal left par rapport a moi 
            if (CurrentX != 7 && CurrentY != 7)
            {
                c = BoardManager.Instance.CheckerMan[CurrentX + 1, CurrentY + 1];
                //#region console stuff black diag left
                //Debug.Log("CurrentX " + CurrentX.ToString());
                //Debug.Log("CurrentY " + CurrentY.ToString());
                //#endregion
                if (c == null) 
                {
                    r[CurrentX + 1, CurrentY + 1] = true;
                }
                else if (c.isWhite) // if it's a white piece we can jump over it 
                {
                    
                    if (CurrentX < 6 && CurrentY < 6)
                    {
                        c2 = BoardManager.Instance.CheckerMan[CurrentX + 2, CurrentY + 2];
                        //c3 = BoardManager.Instance.CheckerMan[CurrentX + 1, CurrentY + 1];
                        if (c2 == null)
                        {
                            r[CurrentX + 2, CurrentY + 2] = true;
                        }
                    }
                }
            }
            //Diagonal Right par rapport à moi 
            if (CurrentX != 0 && CurrentY != 7)
            {
                c = BoardManager.Instance.CheckerMan[CurrentX - 1, CurrentY + 1];
                //#region console stuff black diag right
                //Debug.Log("CurrentX " + CurrentX.ToString());
                //Debug.Log("CurrentY " + CurrentY.ToString());
                //#endregion
                if (c == null) // && !c.isWhite)
                {
                    r[CurrentX - 1, CurrentY + 1] = true;
                }
                else if (c.isWhite)
                {
                    
                    if (CurrentX > 1 && CurrentY < 6)
                    {
                        c2 = BoardManager.Instance.CheckerMan[CurrentX - 2, CurrentY + 2];
                        if (c2 == null)
                        {
                            r[CurrentX - 2, CurrentY + 2] = true;
                        }
                    }
                }
            }
        }
        #endregion
        return r;  // find a way to return X,Y destroy
    }
}
