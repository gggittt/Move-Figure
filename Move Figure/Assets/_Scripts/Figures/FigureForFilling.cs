using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FigureForFilling : Figure
{
    public bool IsFilled;
    //private MovingFigure _filledBy;
    
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

        
        var figureToMove = 

        FindObjectOfType<MovingFigureSelector>().GetSelected();
        if (figureToMove == null)
        {
            Debug.Log($"<color=red> Not selected  </color>");
            return;
        }
        
        
        if (figureToMove.Size <= _size)
        {
            MoveSelected(figureToMove);
            FindObjectOfType<GameOver>().CheckWin();
        }
        else
        {
            HandleMistake();
        }
        
    }

    private void HandleMistake()
    {
        

    }

    private void MoveSelected(MovingFigure figureToMove)
    {
        //_filledBy = figureToMove;
        IsFilled = true;
        figureToMove.transform.position = transform.position;
        FindObjectOfType<Player>().AddSuccessfulMove();

    }
}


