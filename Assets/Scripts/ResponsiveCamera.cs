using UnityEngine;

public class ResponsiveCamera : MonoBehaviour
{
    public float targetWidth = 1920f;
    public float targetHeight = 1080f;

    void Start()
    {
        AdjustCamera();
    }

    void AdjustCamera()
    {
        float targetAspect = targetWidth / targetHeight;
        float screenAspect = (float)Screen.width / Screen.height;

        Camera cam = GetComponent<Camera>();

        if (screenAspect >= targetAspect)
        {
            // Wider screen → match height
            cam.orthographicSize = targetHeight / 200f;
        }
        else
        {
            // Taller screen → scale height to maintain width
            float differenceInSize = targetAspect / screenAspect;
            cam.orthographicSize = targetHeight / 200f * differenceInSize;
        }
    }
}
