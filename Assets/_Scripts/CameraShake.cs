using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    public Transform cameraTransform;
    public float shakeDuration = 0.5f;
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;
    public Image fadeImage;
    public float fadeDuration = 1.0f;

    private Vector3 originalPos;
    private float currentShakeDuration;

    void Start()
    {
        if (cameraTransform == null)
        {
            cameraTransform = GetComponent(typeof(Transform)) as Transform;
        }

        if (fadeImage != null)
        {
            Color color = fadeImage.color;
            color.a = 1f;
            fadeImage.color = color;
            fadeImage.gameObject.SetActive(false);
        }
    }

    void OnEnable()
    {
        originalPos = cameraTransform.localPosition;
    }

    void Update()
    {
        if (currentShakeDuration > 0)
        {
            cameraTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
            currentShakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            currentShakeDuration = 0f;
            cameraTransform.localPosition = originalPos;
        }
    }

    public void TriggerShakeAndFade()
    {
        currentShakeDuration = shakeDuration;
        if (fadeImage != null)
        {
            StartCoroutine(FadeOut());
        }
    }

    private IEnumerator FadeOut()
    {
        fadeImage.gameObject.SetActive(true);

        float fadeOutTime = 0f;
        while (fadeOutTime < fadeDuration)
        {
            fadeOutTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, fadeOutTime / fadeDuration);
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, alpha);
            yield return null;
        }

        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0f);
        fadeImage.gameObject.SetActive(false);
    }
}
