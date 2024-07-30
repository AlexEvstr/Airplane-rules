using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlButton : MonoBehaviour
{
    [SerializeField] private GameObject _doneMark;

    public void TiltBtn()
    {
        PlayerPrefs.SetString("ControlType", "Tilt");
        _doneMark.transform.SetParent(transform);
        RectTransform rectTransform = _doneMark.GetComponent<RectTransform>();

        rectTransform.anchoredPosition = new Vector2(150, 150);
    }

    public void SwipeBtn()
    {
        PlayerPrefs.SetString("ControlType", "Swipe");
        _doneMark.transform.SetParent(transform);
        RectTransform rectTransform = _doneMark.GetComponent<RectTransform>();

        rectTransform.anchoredPosition = new Vector2(150, 150);
    }
}
