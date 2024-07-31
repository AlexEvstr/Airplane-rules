using UnityEngine;

public class GameMusicController : MonoBehaviour
{
    [SerializeField] private GameObject _musicOn;
    [SerializeField] private GameObject _musicOff;
    [SerializeField] private AudioClip _clickSound;
    [SerializeField] private AudioClip _trueSound;
    [SerializeField] private AudioClip _falseSound;
    [SerializeField] private AudioClip _loseSound;
    [SerializeField] private AudioClip _winSound;
    private AudioSource _audioSource;

    private void Start()
    {
        Time.timeScale = 1;
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

    public void PlayClickClip()
    {
        _audioSource.PlayOneShot(_clickSound);
    }

    public void TrueSound()
    {
        _audioSource.PlayOneShot(_trueSound);
    }

    public void FalseSound()
    {
        _audioSource.PlayOneShot(_falseSound);
    }

    public void LoseSound()
    {
        _audioSource.PlayOneShot(_loseSound);
    }

    public void WinSound()
    {
        _audioSource.PlayOneShot(_winSound);
    }

}