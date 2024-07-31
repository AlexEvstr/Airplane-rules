using UnityEngine;

public class GameButtons : MonoBehaviour
{
    [SerializeField] private GameObject _pause;
    [SerializeField] private GameObject _tutorial;
    [SerializeField] private SceneTransition _sceneTransition;

    private void Start()
    {
        Time.timeScale = 1;
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        string entered = PlayerPrefs.GetString("seenGameTutorial", "");
        if (entered == "")
        {
            _tutorial.SetActive(true);
        }
    }

    public void PauseGame()
    {
        _pause.SetActive(true);
    }

    public void ResumeGame()
    {
        _pause.SetActive(false);
    }

    public void MenuButton()
    {
        _sceneTransition.TransitionToScene("menu");
    }

    public void TryAgain()
    {
        _sceneTransition.TransitionToScene("gameplay");
    }

    public void OpenTutorial()
    {
        _tutorial.SetActive(true);
    }

    public void CloseTutorial()
    {
        _tutorial.SetActive(false);
        PlayerPrefs.SetString("seenGameTutorial", "yes");
    }
}