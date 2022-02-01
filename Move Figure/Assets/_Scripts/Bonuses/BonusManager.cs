using UnityEngine;

public class BonusManager : MonoBehaviour
{
    private ReduceSizeFigure _selectedBonus;

    [SerializeField] private UiEnergy _prefabUiEnergy;
    [SerializeField] private RectTransform _playerInfoUi;
    private UiEnergy _uiEnergy;

    private void SelectBonus(ReduceSizeFigure reduceSizeFigure)
    {
        Debug.Log($"<color=cyan> выбран бонус {reduceSizeFigure}  </color>");
        _selectedBonus = reduceSizeFigure;
    }

    public void TryApplyBonuses(PieceToMove pieceToMove)
    {
        if (_selectedBonus == null)
            return;

        if (GameData.StartEnergy <= 0)
        {
            ShowLackEnergyMessage();
            return;
        }
        
        ReduceEnergy();
        ApplyBonus(pieceToMove);
    }

    private void Awake()
    {
        if (GameData.UseBonuses == false)
            return;

        var bonuses = FindObjectsOfType<ReduceSizeFigure>();
        foreach (var point in bonuses)
        {
            point.OnClick += BonusClickHandler;
        }

        _uiEnergy = Instantiate(_prefabUiEnergy, _playerInfoUi);

        _uiEnergy.UpdateEnergy(GameData.StartEnergy);
    }

    private void BonusClickHandler(ReduceSizeFigure sender)
    {
        SelectBonus(sender);
    }


    private void ReduceEnergy()
    {
        GameData.StartEnergy--;
        _uiEnergy.UpdateEnergy(GameData.StartEnergy);
    }

    private void ShowLackEnergyMessage()
    {
        Debug.Log($"<color=red> Не хватает энергии. </color>");
        Deselect();
    }


    private void ApplyBonus(PieceToMove pieceToMove)
    {
        pieceToMove.ReduceSize(_selectedBonus.BonusAmount);
        Debug.Log($"<color=green> применил бонус {_selectedBonus}  </color>");

        Destroy(_selectedBonus.gameObject);
        Deselect();
    }

    private void Deselect()
    {
        _selectedBonus = null;
    }
}