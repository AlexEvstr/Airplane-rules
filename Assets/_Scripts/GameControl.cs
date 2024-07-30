using UnityEngine;

public class GameControl : MonoBehaviour
{
    private void OnEnable()
    {
        string controlType = PlayerPrefs.GetString("ControlType", "Tilt");
        if (controlType == "Tilt")
        {
            GetComponent<TiltControl>().enabled = true;
        }
        else
        {
            GetComponent<PlaneController>().enabled = true;
        }
    }
}