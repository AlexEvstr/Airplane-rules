using UnityEngine;
using TMPro;

public class GameLevelCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentLevelText;
    [SerializeField] private TMP_Text _resultText;
    [SerializeField] private GameObject _victory;
    private GameMusicController _gameMusicController;
    private int LevelCurrent;
    private int _scoreToWin;
    private int _score;

    private void Start()
    {
        Time.timeScale = 1;
        _gameMusicController = GetComponent<GameMusicController>();
        LevelCurrent = PlayerPrefs.GetInt("LevelCurrent", 1);
        _scoreToWin = LevelCurrent * 2;
        _currentLevelText.text = $"LEVEL {LevelCurrent} \n COMPLETED";
        _resultText.text = $"{_score}/{_scoreToWin}";
    }

    public void IncreaseScore()
    {
        _score++;
        _resultText.text = $"{_score}/{_scoreToWin}";
        if (_score == _scoreToWin)
        {
            IncreaseLevelIndex();
        }
    }

    public void IncreaseLevelIndex()
    {
        _victory.SetActive(true);
        _gameMusicController.WinSound();
        LevelCurrent++;
        int bestLevel = PlayerPrefs.GetInt("LevelBest", 1);
        PlayerPrefs.SetInt("LevelCurrent", LevelCurrent);
        if (bestLevel < LevelCurrent)
        {
            bestLevel = LevelCurrent;
            PlayerPrefs.SetInt("LevelBest", bestLevel);
        }
        //Time.timeScale = 0;
    }
}