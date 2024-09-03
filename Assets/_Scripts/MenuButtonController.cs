using UnityEngine;

public class MenuButtonController : MonoBehaviour
{
    [SerializeField] private GameObject _musicOn;
    [SerializeField] private GameObject _musicOff;
    [SerializeField] private GameObject _mainPopup;
    [SerializeField] private GameObject _onBoard;
    [SerializeField] private GameObject _settignsPopup;
    [SerializeField] private GameObject _levelsPopup;
    [SerializeField] private GameObject _tutorialPopup;
    [SerializeField] private AudioClip _clickSound;
    private AudioSource _audioSource;

    private void Start()
    {
        Time.timeScale = 1;

        if (PlayerPrefs.GetInt("OnBoardShow", 0) == 0)
        {
            _onBoard.SetActive(true);
        }

        _audioSource = GetComponent<AudioSource>();
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        AudioListener.volume = PlayerPrefs.GetFloat("music", 1);
        if (AudioListener.volume == 1)
        {
            _musicOn.SetActive(true);
            _musicOff.SetActive(false);
        }
        else
        {
            _musicOff.SetActive(true);
            _musicOn.SetActive(false);
        }
    }

    public void CloseOnBoard()
    {
        _onBoard.SetActive(false);
        PlayerPrefs.SetInt("OnBoardShow", 1);
    }

    public void OffMusic()
    {
        _musicOn.SetActive(false);
        _musicOff.SetActive(true);
        AudioListener.volume = 0;
        PlayerPrefs.SetFloat("music", 0);
    }

    public void OnMusic()
    {
        _musicOn.SetActive(true);
        _musicOff.SetActive(false);
        AudioListener.volume = 1;
        PlayerPrefs.SetFloat("music", 1);
    }

    public void OpenSetttings()
    {
        _mainPopup.SetActive(false);
        _settignsPopup.SetActive(true);
    }

    public void CloseSettings()
    {
        _settignsPopup.SetActive(false);
        _mainPopup.SetActive(true);
    }

    public void OpenLevels()
    {
        _mainPopup.SetActive(false);
        _levelsPopup.SetActive(true);
    }

    public void CloseLevels()
    {
        _levelsPopup.SetActive(false);
        _mainPopup.SetActive(true);
    }

    public void OpenTutorial()
    {
        _mainPopup.SetActive(false);
        _tutorialPopup.SetActive(true);
    }

    public void CloseTutorial()
    {
        _tutorialPopup.SetActive(false);
        _mainPopup.SetActive(true);
    }

    public void PlayClickClip()
    {
        _audioSource.PlayOneShot(_clickSound);
    }
}