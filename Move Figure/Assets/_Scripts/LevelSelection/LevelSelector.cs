using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private string _levelsScenesNameBegin = "Level";
    
    [SerializeField] private InputField _startEnergyInput;


    public void OnUseBonusesToggleChanged(bool shouldUseBonuses)
    {
        GameData.UseBonuses = shouldUseBonuses;

        _startEnergyInput.gameObject.SetActive(shouldUseBonuses);
    }

    public void LoadLevel(int index)
    {
        if (GameData.UseBonuses)
        {
            var isEnergyAmountInstalled = TrySetStartEnergy();
            if (isEnergyAmountInstalled == false )
            {
                return;
            }
        }

        SceneManager.LoadScene(_levelsScenesNameBegin + index);
    }

    
    private bool TrySetStartEnergy()
    {
        var isParsed = int.TryParse(_startEnergyInput.text, out int result);
        
        if (isParsed == false)
        {
            Debug.Log($"<color=red> Введите количество энергии  </color>");
            return false;
        }

        Debug.Log($"<color=green> GameData.StartEnergy = {result}  </color>");

        GameData.StartEnergy = result;
        return true;
    }

}