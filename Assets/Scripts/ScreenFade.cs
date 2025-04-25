using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenFade : MonoBehaviour
{
    public Image fadeImage;
    public float fadeSpeed = 1f;

    public void FadeInThenOut(System.Action onFadeMidpoint)
    {
        StartCoroutine(FadeRoutine(onFadeMidpoint));
    }

    private IEnumerator FadeRoutine(System.Action onFadeMidpoint)
    {
        // Fade to black
        while (fadeImage.color.a < 1f)
        {
            Color color = fadeImage.color;
            color.a += fadeSpeed * Time.deltaTime;
            fadeImage.color = color;
            yield return null;
        }

        // Call the midpoint action (e.g. show wedding)
        onFadeMidpoint?.Invoke();

        // Wait briefly if desired
        yield return new WaitForSeconds(0.3f);

        // Fade back in
        while (fadeImage.color.a > 0f)
        {
            Color color = fadeImage.color;
            color.a -= fadeSpeed * Time.deltaTime;
            fadeImage.color = color;
            yield return null;
        }
    }
}
