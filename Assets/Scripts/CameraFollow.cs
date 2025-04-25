using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public bool stopFollowing = false;

    void LateUpdate()
    {
        if (stopFollowing) return;
        if (player != null)
        {
            Vector3 desiredPosition = new Vector3(player.position.x + offset.x, offset.y, offset.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
