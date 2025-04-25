using UnityEngine;

public class Collectable : MonoBehaviour
{
    public string collectableType;
    private CollectableSpawner spawner;
    private Camera cam;

    void Start()
    {
        spawner = FindObjectOfType<CollectableSpawner>();
        cam = Camera.main;
    }


    void Update()
    {
        if (transform.position.x + GetComponent<SpriteRenderer>().bounds.size.x < cam.transform.position.x - 30)
        {

            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && spawner != null)
        {
            Destroy(gameObject);
        }
    }
}
