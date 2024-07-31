using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaitingManager : MonoBehaviour
{
    private void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        StartCoroutine(LoadMenuScene());
    }

    private IEnumerator LoadMenuScene()
    {
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene("menu");
    }
}