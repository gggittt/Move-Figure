using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusManager : MonoBehaviour
{
    private ReduceSizeFigure _selectedBonuses;
    [SerializeField] private int _energyAmount = 2;
    [SerializeField] private UiEnergy _uiEnergy;
    
    


    public void SelectBonus(ReduceSizeFigure reduceSizeFigure)
    {
        Debug.Log($"<color=cyan> выбран бонус {reduceSizeFigure}  </color>");
        _selectedBonuses = reduceSizeFigure;
    }

    public void TryApplyBonuses(MovingFigure movingFigure)
    {
        if (_energyAmount <= 0)
        {
            ShowLackEnergyMessage();
            return;
        }

        if (_selectedBonuses)
        {
            ReduceEnergy();
            ApplyBonus(movingFigure);
        }
    }

    private void Start()
    {
        _uiEnergy.gameObject.SetActive(true);//а по умолчанию типа выкл, чтобы если bonuses logic отключен - в ui место не занимала и не путала игрока
        _uiEnergy.UpdateEnergy(_energyAmount);
    }

    private void ReduceEnergy()
    {
        _energyAmount--;
        _uiEnergy.UpdateEnergy(_energyAmount);
    }

    private void ShowLackEnergyMessage()
    {
        Debug.Log($"<color=red> Не хватает энергии. </color>");
    }


    private void ApplyBonus(MovingFigure movingFigure)
    {
        movingFigure.ReduceSize(_selectedBonuses.BonusAmount);
        Debug.Log($"<color=green> применил бонус {_selectedBonuses}  </color>");

        Destroy(_selectedBonuses.gameObject);
        _selectedBonuses = null; //и так обнулится же
    }
}