using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelPicker : MonoBehaviour
{
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(GoToGame);

        int levelIndex = int.Parse(gameObject.name);
        int bestLevel = PlayerPrefs.GetInt("LevelBest", 1);

        if (bestLevel >= levelIndex)
        {
            transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            _button.enabled = false;
        }
    }

    public void GoToGame()
    {
        PlayerPrefs.SetInt("LevelCurrent", int.Parse(gameObject.name));
        SceneManager.LoadScene("gameplay");
    }
}