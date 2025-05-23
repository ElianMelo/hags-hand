using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSystemManager : MonoBehaviour
{
    public static LevelSystemManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GoToLore()
    {
        SceneManager.LoadScene("Lore");
    }

    public void GoToLevel()
    {
        SceneManager.LoadScene("Level");
    }

    public void GoToWin()
    {
        SceneManager.LoadScene("Win");
    }

    public void GoToLose()
    {
        SceneManager.LoadScene("Lose");
    }
}
