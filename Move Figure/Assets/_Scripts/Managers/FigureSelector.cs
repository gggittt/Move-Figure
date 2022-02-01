using UnityEngine;

public class FigureSelector : MonoBehaviour
{
    private MovingFigure _selected;
    //private FigureForFilling[] _figuresForFilling;
    //private MovingFigure[] _movingFigures;

    private void Awake()
    {
        InitCircles();
        InitSquares();
    }

    private void SquareClickHandler(MovingFigure sender)
    {
        _selected = sender;
    }
    
    private void CircleClickHandler(FigureForFilling sender)
    {
        
        if (_selected == null)
        {
            Debug.Log($"<color=red> Not selected  </color>");
            return;
        }
        
        
        if (_selected.Size <= sender.Size)
        {
            MoveSelected(sender.transform.position);
            sender.IsFilled = true;

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

    private void MoveSelected(Vector3 targetPosition)
    {
        //_filledBy = figureToMove;
        _selected.transform.position = targetPosition;
        FindObjectOfType<Player>().AddSuccessfulMove();

    }
    

    private void InitSquares()
    {
        var movingFigures = FindObjectsOfType<MovingFigure>();
        foreach (var point in movingFigures)
        {
            point.OnClick += SquareClickHandler;
        }
    }

    private void InitCircles()
    {
        var figuresForFilling = FindObjectsOfType<FigureForFilling>();
        foreach (var point in figuresForFilling)
        {
            point.OnClick += CircleClickHandler;
        }
    }
    
}