using UnityEngine;
using System.Collections;
public abstract class Checkers : MonoBehaviour
{
    public int currentX;
    #region Accesseurs currentX
    public int CurrentX
    {
        get
        {
            return this.currentX;
        }
        set
        {
            this.currentX = value;
        }
    }
    #endregion
    public int currentY;
    #region Accesseur currentY
    public int CurrentY
    {
        get
        {
            return this.currentY;
        }
        set
        {
            this.currentY = value;
        }
    }
    #endregion
    public bool isWhite;
    public void SetPosition(int x, int y)
    {
        currentX = x;
        currentY = y;
    }
    public virtual bool[,] PossibleMove()
    {
        return new bool[8,8];
    }
}
