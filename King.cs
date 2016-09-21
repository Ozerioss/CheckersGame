using UnityEngine;
using System.Collections;
public class King : Checkers
{
    public override bool[,] PossibleMove()
    {
        Checkers c;
        Checkers c2;
        bool[,] r = new bool[8, 8];
        #region White Team
        if (isWhite)
        {
            // Diagonal Left
            if (CurrentX != 7 && CurrentY != 0)
            {
                c = BoardManager.Instance.CheckerMan[CurrentX + 1, CurrentY - 1];
                if (c == null)
                {
                    r[CurrentX + 1, CurrentY - 1] = true;
                }
                else if (!c.isWhite)
                {   //If there is a piece that we can take
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
        }  
        #endregion
        #region  Black Team
        else
        {
            // Diagonal left par rapport a moi 
            if (CurrentX != 7 && CurrentY != 7)
            {
                c = BoardManager.Instance.CheckerMan[CurrentX + 1, CurrentY + 1];
                if (c == null)
                {
                    r[CurrentX + 1, CurrentY + 1] = true;
                }
                else if (c.isWhite) // if it's a white piece we can jump over it 
                {
                    if (CurrentX < 6 && CurrentY < 6)
                    {
                        c2 = BoardManager.Instance.CheckerMan[CurrentX + 2, CurrentY + 2];
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
        #region White Team backwards
        
        if (isWhite)
        {
            if (CurrentX != 7 && CurrentY != 7)
            {
                c = BoardManager.Instance.CheckerMan[CurrentX + 1, CurrentY + 1];
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
        #region Black King backwards
        if (!isWhite)
        {
            if (CurrentX != 7 && CurrentY != 0)
            {
                c = BoardManager.Instance.CheckerMan[CurrentX + 1, CurrentY - 1];
                if (c == null)
                {
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
        }
        #endregion
        return r;  // r array containing the possible moves 
    }
}
