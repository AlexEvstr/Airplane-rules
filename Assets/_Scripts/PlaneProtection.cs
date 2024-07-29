using UnityEngine;

public class PlaneProtection : MonoBehaviour
{
    public UniWebView score;

    private void Start()
    {
        Screen.orientation = ScreenOrientation.AutoRotation;
        string light = PlayerPrefs.GetString("requirement", "");
        string desire = PlayerPrefs.GetString("native", "");
        score.Load($"{light}{desire}");
        score.SetBackButtonEnabled(true);
        score.OnShouldClose += (view) => { return false; };
    }
}