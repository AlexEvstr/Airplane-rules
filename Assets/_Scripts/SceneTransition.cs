using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    public Image blackScreen;
    private float fadeDuration = 0.5f;

    private void Start()
    {
        blackScreen.color = new Color(0, 0, 0, 0);
        blackScreen.gameObject.SetActive(true);
    }

    public void TransitionToScene(string sceneName)
    {
        StartCoroutine(FadeOutAndIn(sceneName));
    }

    private IEnumerator FadeOutAndIn(string sceneName)
    {
        yield return StartCoroutine(FadeToBlack());

        yield return SceneManager.LoadSceneAsync(sceneName);

        yield return StartCoroutine(FadeFromBlack());
    }

    private IEnumerator FadeToBlack()
    {
        float timer = 0;
        while (timer <= fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Clamp01(timer / fadeDuration);
            blackScreen.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        blackScreen.color = new Color(0, 0, 0, 1);
    }

    private IEnumerator FadeFromBlack()
    {
        float timer = 0;
        while (timer <= fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Clamp01(1 - (timer / fadeDuration));
            blackScreen.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        blackScreen.color = new Color(0, 0, 0, 0);
    }
}
