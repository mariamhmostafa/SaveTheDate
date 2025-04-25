using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShowHeart : MonoBehaviour
{
    public GameObject heartObject;

    public void Start()
    {
        heartObject.SetActive(false);
    }

    public void ShowHeartAfterDelay(float delay)
    {
        StartCoroutine(ShowAfterDelay(delay));
    }

    private IEnumerator ShowAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        heartObject.SetActive(true);
    }
}
