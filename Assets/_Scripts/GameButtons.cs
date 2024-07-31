using UnityEngine;
using UnityEngine.SceneManagement;

public class GameButtons : MonoBehaviour
{
    [SerializeField] private GameObject _pause;
    [SerializeField] private GameObject _tutorial;

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
        SceneManager.LoadScene("menu");
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("gameplay");
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