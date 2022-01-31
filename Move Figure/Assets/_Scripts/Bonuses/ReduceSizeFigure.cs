using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReduceSizeFigure : Figure
{
    [SerializeField] private int _bonusAmount = 1;
    public Action<ReduceSizeFigure> OnClick;

    public int BonusAmount => _bonusAmount;
    
    private void OnDisable()
    {
        OnClick = null;
    }
    
    private void OnMouseDown()
    {
        OnClick.Invoke(this);
    }
}


