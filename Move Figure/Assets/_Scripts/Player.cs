using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _moves;
    [SerializeField] private UiPlayer _ui;

    public int Moves { get; set; }

    public void AddSuccessfulMove()
    {
        _moves++;
        UpdateSuccessfulMove();
    }

    private void Start()
    {
        UpdateSuccessfulMove();
    }

    private void UpdateSuccessfulMove() =>         _ui.UpdateSuccessMoves(_moves);

}


