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

    void Start()
    {
        StartCoroutine(Blink());
    }

    private IEnumerator Blink()
    {
        while (true)
        {
            textToBlink.enabled = !textToBlink.enabled;
           yield return new WaitForSecondsRealtime(blinkRate);
        }
    }

    private void Update()
    {
        if (!hasStarted)
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
