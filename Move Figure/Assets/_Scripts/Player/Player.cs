using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private UiPlayer _playerUi;
    
    [SerializeField] private int _moves;
    
    

    public void AddSuccessfulMove()
    {
        _moves++;
        UpdateSuccessfulMoveUi();
    }

    private void Awake()
    {
        UpdateSuccessfulMoveUi();
        
    }

    private void UpdateSuccessfulMoveUi() =>         _playerUi.UpdateSuccessMoves(_moves);

}


