﻿using UnityEngine;

public class BonusManager : MonoBehaviour
{
    private ReduceSizeFigure _selectedBonus;
    [SerializeField] private int _energyAmount = 2;
    [SerializeField] private UiEnergy _uiEnergy;
    
    


    public void SelectBonus(ReduceSizeFigure reduceSizeFigure)
    {
        Debug.Log($"<color=cyan> выбран бонус {reduceSizeFigure}  </color>");
        _selectedBonus = reduceSizeFigure;
    }

    public void TryApplyBonuses(MovingFigure movingFigure)
    {
        if (_energyAmount <= 0)
        {
            ShowLackEnergyMessage();
            return;
        }

        if (_selectedBonus)
        {
            ReduceEnergy();
            ApplyBonus(movingFigure);
        }
    }

    private void Awake()
    {
        var bonuses = FindObjectsOfType<ReduceSizeFigure>();
        foreach (var point in bonuses)
        {
            point.OnClick += BonusClickHandler;
        }
    }

    private void BonusClickHandler(ReduceSizeFigure sender)
    {
        SelectBonus(sender);
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
        Deselect();
    }


    private void ApplyBonus(MovingFigure movingFigure)
    {
        movingFigure.ReduceSize(_selectedBonus.BonusAmount);
        Debug.Log($"<color=green> применил бонус {_selectedBonus}  </color>");

        Destroy(_selectedBonus.gameObject);
        Deselect();
    }

    private void Deselect()
    {
        _selectedBonus = null; //и так обнулится же
    }
}