using UnityEngine;
using UnityEngine.UI;

public class GameMusicController : MonoBehaviour
{
    [SerializeField] private Image _musicOn;
    [SerializeField] private Image _musicOff;
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
            //_musicOn.SetActive(true);
            _musicOff.color = new Color(1, 1, 1, 1);
        }
        else
        {
            _musicOn.color = new Color(1, 1, 1, 0.4f);
        }
    }

    public void OffMusic()
    {
        _musicOn.color = new Color(1, 1, 1, 0.4f); 
        _musicOff.color = new Color(1, 1, 1, 1);
        AudioListener.volume = 0;
        PlayerPrefs.SetFloat("music", 0);
    }

    public void OnMusic()
    {
        _musicOn.color = new Color(1, 1, 1, 1);
        _musicOff.color = new Color(1, 1, 1, 0.4f);
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