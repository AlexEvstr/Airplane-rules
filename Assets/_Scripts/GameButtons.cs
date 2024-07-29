using UnityEngine;
using UnityEngine.SceneManagement;

public class GameButtons : MonoBehaviour
{
    [SerializeField] private GameObject _pause;

    private void Start()
    {
        Time.timeScale = 1;
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    public void PauseGame()
    {
        _pause.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        _pause.SetActive(false);
        Time.timeScale = 1;
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("menu");
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("gameplay");
    }
}