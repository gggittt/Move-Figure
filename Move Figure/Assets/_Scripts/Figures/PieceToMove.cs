using System;
using UnityEngine;

public class PieceToMove : Figure
{
    public Action<PieceToMove> OnClick;
    public int Size => _size;
    private PieceForFilling _lastFilled;

    public void ReduceSize(int amount)
    {
        _size -= amount;
        CalculateScale();
    }

    protected override void SetScale()
    {
        CalculateScale();
    }

    private void CalculateScale()
    {
        var squareDiagonalCoefficient = Math.Sqrt(2) / 2;
        var newSquareScale = _size * (float) squareDiagonalCoefficient;

        DrawWithNewScale(newSquareScale);
        void DrawWithNewScale(float squareScale)
        {
            transform.localScale = new Vector3(squareScale, squareScale, squareScale);
        }
    }

    private void OnDisable()
    {
        OnClick = null;
    }

    private void OnMouseDown()
    {
        OnClick?.Invoke(this);
    }

    public void MoveTo(PieceForFilling target)
    {
        if (_lastFilled)
        {
            _lastFilled.IsFilled = false;
        }
        
        transform.position = target.transform.position;
        _lastFilled = target;
    }
}