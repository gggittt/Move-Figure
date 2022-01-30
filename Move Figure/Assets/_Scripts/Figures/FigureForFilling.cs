using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class FigureForFilling : MonoBehaviour
{
    public bool IsFilled;
    private MovingFigure _filledBy;
    [SerializeField] private int _size = 6;

    private void OnValidate()
    {
        transform.localScale = new Vector3(_size, _size, _size);
    }

    private void OnMouseDown()
    {
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
        _filledBy = figureToMove;
        IsFilled = true;
        figureToMove.transform.position = transform.position;
        FindObjectOfType<Player>().AddSuccessfulMove();

    }
}


