using System;
using UnityEngine;


public class PieceForFilling : Figure
{
    public bool IsFilled { get; set; }
    public int Size => _size;
    
    public Action<PieceForFilling> OnClick;
    
    private void OnMouseDown()
    {
        OnClick?.Invoke(this);
    }


    
}


