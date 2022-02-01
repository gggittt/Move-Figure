using UnityEngine;
using UnityEngine.UI;

public class UiEnergy : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private string  _successMovesDescription = "Energy: ";

    public void UpdateEnergy(int newEnergy)
    {
        _text.text = _successMovesDescription + newEnergy;
    }
}


