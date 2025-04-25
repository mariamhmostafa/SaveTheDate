using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    public GameObject cam;
    public float parallaxEffect;

    private float spriteWidth;
    private Transform camTransform;
    private Vector3 lastCamPosition;

    void Start()
    {
        camTransform = cam.transform;
        lastCamPosition = camTransform.position;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        spriteWidth = sr.bounds.size.x;
    }

    void Update()
    {
        Vector3 deltaMovement = camTransform.position - lastCamPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffect, 0f, 0f);
        lastCamPosition = camTransform.position;

        float camHorizontalPosition = camTransform.position.x;
        float distanceFromCamera = camHorizontalPosition - transform.position.x;

        if (Mathf.Abs(distanceFromCamera) >= spriteWidth)
        {
            float offset = spriteWidth * 2f * Mathf.Sign(distanceFromCamera);
            transform.position += new Vector3(offset, 0f, 0f);
        }
    }
}
