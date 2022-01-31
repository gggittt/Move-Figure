using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FigureForFilling : Figure
{
    public bool IsFilled { get; set; }

    //private MovingFigure _filledBy;
    public int Size => _size;

    
    public Action<FigureForFilling> OnClick;
    public event Action<float> OnHealthPctChanged = delegate {  }; // delegate (float f) {  };

    
    
    public void Some()
    {
        OnHealthPctChanged += HandleHealthChanged;
        OnHealthPctChanged(4f);//= X?.Invoke();
        OnHealthPctChanged = null;
    }

    private void HandleHealthChanged(float obj)
    {
        Debug.Log($"<color=black> {obj}  </color>");
    }
    

    private void OnMouseDown()
    {
        Debug.Log($"<color=cyan> клик на круг  </color>");
        OnClick?.Invoke(this);
        
    }

    
}


