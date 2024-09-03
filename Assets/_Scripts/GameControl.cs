using UnityEngine;

public class GameControl : MonoBehaviour
{
    [SerializeField] private GameObject _joystick;

    private void OnEnable()
    {
        string controlType = PlayerPrefs.GetString("ControlType", "Tilt");
        if (controlType == "Tilt")
        {
            GetComponent<TiltControl>().enabled = true;
        }
        else
        {
            _joystick.SetActive(true);
            GetComponent<PlaneController>().enabled = true;
        }
    }
}