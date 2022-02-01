using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [SerializeField] private int _moves;
    [FormerlySerializedAs("_ui")] [SerializeField] private UiPlayer _playerUi;//но нужно чтоб его не двигали. т.к. именно в него ребенко создаю energyUi

    [SerializeField] private bool _useBonuses;
    //[SerializeField] private RectTransform _playerUi;
    [SerializeField] private UiEnergy _prefabUiEnergy;//и потом результат прокинуть в BonusSelector/ да и сам BonusSelector тоже инстанциировать из префаба? бред!
    
    

    public void AddSuccessfulMove()
    {
        _moves++;
        UpdateSuccessfulMoveUi();
    }

    private void Awake()
    {
        UpdateSuccessfulMoveUi();
        if (_useBonuses)
        {
            //в конце, после событий
            //var bonusUi = Instantiate(_prefabUiEnergy, _playerUi.transform);
        }
    }

    private void UpdateSuccessfulMoveUi() =>         _playerUi.UpdateSuccessMoves(_moves);

}


