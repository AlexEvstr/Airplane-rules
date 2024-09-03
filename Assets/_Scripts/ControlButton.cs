using UnityEngine;

public class ControlButton : MonoBehaviour
{
    [SerializeField] private GameObject _doneMark;
    [SerializeField] private GameObject _tiltBtn;
    [SerializeField] private GameObject _swipeBtn;

    private void Start()
    {
        string controlType = PlayerPrefs.GetString("ControlType", "Tilt");
        if (controlType == "Tilt")
        {
            _doneMark.transform.SetParent(_tiltBtn.transform);
            RectTransform rectTransform = _doneMark.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(225, 125);
        }
        else
        {
            _doneMark.transform.SetParent(_swipeBtn.transform);
            RectTransform rectTransform = _doneMark.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(225, 125);
        }

    }

    public void TiltBtn()
    {
        PlayerPrefs.SetString("ControlType", "Tilt");
        _doneMark.transform.SetParent(transform);
        RectTransform rectTransform = _doneMark.GetComponent<RectTransform>();

        rectTransform.anchoredPosition = new Vector2(225, 125);
    }

    public void SwipeBtn()
    {
        PlayerPrefs.SetString("ControlType", "Swipe");
        _doneMark.transform.SetParent(transform);
        RectTransform rectTransform = _doneMark.GetComponent<RectTransform>();

        rectTransform.anchoredPosition = new Vector2(225, 125);
    }
}
