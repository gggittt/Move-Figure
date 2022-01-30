using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private FigureForFilling[] _figuresForFillings;
    //private List<FigureForFilling> _figuresForFillings;

    private void Start()
    {
        _figuresForFillings = FindObjectsOfType<FigureForFilling>();
    }

    public void CheckWin()
    {
        var count = _figuresForFillings.Count(point => point.IsFilled);

        Debug.Log($"<color=yellow> done {count} from {_figuresForFillings.Length} </color>");

        var isAllFilled = _figuresForFillings.All(point => point.IsFilled);
        
        if (isAllFilled)
            Win();
    }

    private void Win()
    {
        Debug.Log($"<color=green> All {_figuresForFillings.Length} Filled!  </color>");
    }
}