using UnityEngine;
using System.Collections.Generic;

public class CollectableSpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform player;
    [SerializeField] private List<GameObject> collectablePrefabs;
    [SerializeField] private GameObject bride;
    

    [Header("Spawn Settings")]
    [SerializeField] private float startOffset = 15f;
    [SerializeField] private float spacing = 10f;
    [SerializeField] private float verticalPosition = 22f;

    private float lastCollectableX;
    private HashSet<string> collectedTypes = new HashSet<string>();
    private GameManager gameManager;
    private bool hasTriggered = false;
    private bool brideIsRunning = false;
    private Rigidbody2D brideRb;

    private void Start()
    {
        gameManager = GetComponent<GameManager>();
        brideRb = bride.GetComponent<Rigidbody2D>();
        float spawnX = player.position.x + startOffset;

        foreach (GameObject prefab in collectablePrefabs)
        {
            Vector3 spawnPos = new Vector3(spawnX, verticalPosition, 0);
            Instantiate(prefab, spawnPos, Quaternion.identity);
            spawnX += spacing;
        }
        //change bride position to be in front of the last collectable
        bride.transform.position = new Vector3(spawnX, player.transform.position.y -2 , 0);

        spawnX += spacing;

        lastCollectableX = spawnX - spacing + 20; 
    }

    private void Update()
    {
        if (!hasTriggered && player.position.x > bride.transform.position.x + 7)
        {
            brideIsRunning = true;
        }
        if(brideIsRunning)
        {
            bride.GetComponent<Animator>().SetTrigger("startRunning");
            Camera.main.GetComponent<CameraFollow>().stopFollowing = true;
            brideRb.velocity = new Vector2(15, brideRb.velocity.y);
        }

        if (!hasTriggered && player.position.x > lastCollectableX)
        {
            hasTriggered = true;
            gameManager.OnAllCollectablesFinished();
        }
    }

}
