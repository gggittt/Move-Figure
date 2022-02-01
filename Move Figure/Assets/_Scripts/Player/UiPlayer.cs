using UnityEngine;
using UnityEngine.UI;

public class UiPlayer : MonoBehaviour
{
    [SerializeField] private Text _successMovesText;
    [SerializeField] private string  _successMovesDescription = "Success moves: ";
    

    public void UpdateSuccessMoves(int newValue)
    {
        _successMovesText.text = _successMovesDescription + newValue;
    }
    

}


