using UnityEngine;
using System.Collections;
using TMPro;

public class StartGameManager : MonoBehaviour
{
    public GameObject tapToPlayUI;
    public AudioSource backgroundMusic;
    private bool hasStarted = false;
    public TMP_Text textToBlink;
    public float blinkRate = 0.5f;
    private bool canStart = false;

    void Start()
    {
        StartCoroutine(Blink());
        StartCoroutine(DelayBeforeAllowStart());
    }

    private IEnumerator Blink()
    {
        while (true)
        {
            textToBlink.enabled = !textToBlink.enabled;
           yield return new WaitForSecondsRealtime(blinkRate);
        }
    }

     private IEnumerator DelayBeforeAllowStart()
    {
        yield return new WaitForSecondsRealtime(1.5f); 
        canStart = true;
    }

    private void Update()
    {
        if (!hasStarted && canStart) 
        {
            if (Input.touchCount > 0 || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                StartGame();
            }
        }
    }

    private void StartGame()
    {
        hasStarted = true;
        tapToPlayUI.SetActive(false);
        if (backgroundMusic != null)
        {
            backgroundMusic.Play();
        }

        Time.timeScale = 1;
    }
}
