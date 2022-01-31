using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFigure : Figure
{
    public Action<MovingFigure> OnClick;
    public int Size => _size;

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
    }

    private void DrawWithNewScale(float newSquareScale)//в родителя
    {
        transform.localScale = new Vector3(newSquareScale, newSquareScale, newSquareScale);
    }

    private void OnMouseDown()
    {
        FindObjectOfType<BonusManager>()?.TryApplyBonuses(this);
        
        OnClick?.Invoke(this);
        FindObjectOfType<MovingFigureSelector>().Select(this);
    }
}