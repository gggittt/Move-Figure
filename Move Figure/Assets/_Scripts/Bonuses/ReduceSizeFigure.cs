using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReduceSizeFigure : Figure
{//проблема с мета файлом?
    [SerializeField] private int _bonusAmount = 1;

    public int BonusAmount => _bonusAmount;
    
    private void OnMouseDown()
    {
        FindObjectOfType<BonusManager>().SelectBonus(this);
        
    }
}


