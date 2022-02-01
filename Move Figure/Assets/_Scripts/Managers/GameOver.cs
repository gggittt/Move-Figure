using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private PieceForFilling[] _figuresForFillings;
    [SerializeField] private string _menuSceneName = "LevelMenu";

    private void Start()
    {
        _figuresForFillings = FindObjectsOfType<PieceForFilling>();
    }

    public void CheckWin()
    {
        var count = _figuresForFillings.Count(point => point.IsFilled);

        int winCount = _figuresForFillings.Length;
        
        ShowProgressMessage(count, winCount);

        var isAllFilled = count == winCount;
        
        if (isAllFilled)
            Win();
    }

    private void ShowProgressMessage(int count, int winCount)
    {
        Debug.Log($"<color=yellow> done {count} from {winCount} </color>");
    }

    private void Win()
    {
        Debug.Log($"<color=green> All {_figuresForFillings.Length} Filled!  </color>");
        SceneManager.LoadScene(_menuSceneName);

    }
}