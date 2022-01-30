using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFigureSelector : MonoBehaviour
{
    private MovingFigure _selected;

    public void Select(MovingFigure toSelect)
    {
        Debug.Log($"<color=cyan> selected {toSelect}  </color>");
        _selected = toSelect;
    }

    public MovingFigure GetSelected()
    {
        return _selected;
    }
}