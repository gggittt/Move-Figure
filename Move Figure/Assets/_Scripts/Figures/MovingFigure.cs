using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class MovingFigure : MonoBehaviour
{
    public Action<MovingFigure> OnClick;
    [SerializeField] private int _size = 7; //отдалить камеру, чтобы хватало клеток?
    public int Size => _size;

    public void ReduceSize(int amount)
    {
        _size -= amount;
        CalculateScale();
    }

    private void OnValidate()
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
        FindObjectOfType<BonusSelector>()?.TryApplyBonuses(this);
        
        OnClick?.Invoke(this);
        FindObjectOfType<MovingFigureSelector>().Select(this);
    }
}