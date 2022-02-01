using UnityEngine;

public class FigureSelector : MonoBehaviour
{
    private PieceToMove _selected;
    
    [SerializeField] private BonusManager _bonusManager;
    [SerializeField] private Player _player;
    [SerializeField] private GameOver _gameOver;


    private void Awake()
    {
        InitCircles();
        InitSquares();
    }

    private void SquareClickHandler(PieceToMove sender)
    {
        if (_bonusManager)
            _bonusManager.TryApplyBonuses(sender);
        
        _selected = sender;
    }

    private void CircleClickHandler(PieceForFilling sender)
    {
        if (_selected == null)
        {
            Debug.Log($"<color=red> Moving piece was not selected  </color>");
            return;
        }

        if (sender.IsFilled)
        {
            Debug.Log($"<color=red> Already filled!  </color>");
            return;
        }
        
        if (_selected.Size <= sender.Size)
        {
            MoveSelected(sender);
            sender.IsFilled = true;

            _gameOver.CheckWin();
        }
        else
        {
            HandleMistake();
        }
    }

    private void HandleMistake()
    {
        Debug.Log($"<color=red> не сошлись радиусы  </color>");
    }

    private void MoveSelected(PieceForFilling target)
    {
        _selected.MoveTo(target);
        _player.AddSuccessfulMove();
    }


    private void InitSquares()
    {
        var movingFigures = FindObjectsOfType<PieceToMove>();
        foreach (var point in movingFigures)
        {
            point.OnClick += SquareClickHandler;
        }
    }

    private void InitCircles()
    {
        var figuresForFilling = FindObjectsOfType<PieceForFilling>();
        foreach (var point in figuresForFilling)
        {
            point.OnClick += CircleClickHandler;
        }
    }
}