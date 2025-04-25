using UnityEngine;
using TMPro;
using System.Collections;

public class FinalReveal : MonoBehaviour
{
    public Camera mainCamera;
    public Transform finalSkyPosition;  // empty GameObject placed near sky image
    public float cameraMoveDuration = 2f;
    public TextMeshProUGUI saveTheDateText;
    public TextMeshProUGUI namesText;
    public TextMeshProUGUI dateText;
    public TextMeshProUGUI LocationAndTimeText;
    public TextMeshProUGUI andText;
    public GameObject moon;

    public float delayBeforeReveal = 2f;

    // void Start()
    // {
    //     StartCoroutine(RevealSequence());
    // }

    IEnumerator RevealSequence()
    {
        // Wait a bit after the wedding scene
        yield return new WaitForSeconds(delayBeforeReveal);
        moon.SetActive(false);
        // Smoothly move camera to final sky view
        Vector3 startPos = mainCamera.transform.position;
        Vector3 endPos = new Vector3(
            finalSkyPosition.position.x,
            finalSkyPosition.position.y,
            mainCamera.transform.position.z
        );

        float elapsed = 0f;
        while (elapsed < cameraMoveDuration)
        {
            mainCamera.transform.position = Vector3.Lerp(startPos, endPos, elapsed / cameraMoveDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        mainCamera.transform.position = endPos;

        // Show and animate the text
        saveTheDateText.gameObject.SetActive(true);
        StartCoroutine(FadeInText(saveTheDateText, 1f));
        yield return new WaitForSeconds(1f);
        namesText.gameObject.SetActive(true);
        StartCoroutine(FadeInText(namesText, 2f));
        andText.gameObject.SetActive(true);
        StartCoroutine(FadeInText(andText, 2f));
        yield return new WaitForSeconds(1f);
        LocationAndTimeText.gameObject.SetActive(true);
        StartCoroutine(FadeInText(LocationAndTimeText, 1f));
        yield return new WaitForSeconds(1f);
        dateText.gameObject.SetActive(true);
        StartCoroutine(FadeInText(dateText, 1f));
    }

    IEnumerator FadeInText(TextMeshProUGUI text, float duration)
    {
        text.alpha = 0;
        float t = 0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            text.alpha = Mathf.Lerp(0, 1, t / duration);
            yield return null;
        }
    }

    public void StartFinalReveal()
    {
        StartCoroutine(RevealSequence());
    }

}
