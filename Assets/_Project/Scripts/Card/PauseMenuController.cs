using UnityEngine;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    public GameObject visuals;
    public Button resetLevelButton;
    public Button tutorialButton;
    public Button menuButton;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            visuals.SetActive(!visuals.activeSelf);
        }
    }
    void Start()
    {
        resetLevelButton.onClick.AddListener(OnResetLevel);
        tutorialButton.onClick.AddListener(OnTutorial);
        menuButton.onClick.AddListener(OnMenu);
    }

    private void OnDestroy()
    {
        resetLevelButton.onClick.RemoveAllListeners();
        tutorialButton.onClick.RemoveAllListeners();
        menuButton.onClick.RemoveAllListeners();
    }

    private void OnResetLevel()
    {
        LevelSystemManager.Instance.GoToLevel();
    }

    private void OnMenu()
    {
        LevelSystemManager.Instance.GoToMenu();
    }

    private void OnTutorial()
    {

    }
}
