using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    //private const int FromArrayToHumanDimension = 1;
    [SerializeField] private string  _levelsScenesNameBegin = "Level";
    

    public void LoadLevel(int index)
    {
        //index += FromArrayToHumanDimension;

        Debug.Log($"<color=cyan> LoadLevel= {index} </color>");

        SceneManager.LoadScene(_levelsScenesNameBegin + index);
    }
    

}


