using UnityEngine;
using System.Collections.Generic;

public class CollectableSpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform player;
    [SerializeField] private List<GameObject> collectablePrefabs;

    [Header("Spawn Settings")]
    [SerializeField] private float startOffset = 15f;
    [SerializeField] private float spacing = 10f;
    [SerializeField] private float verticalPosition = 22f;

    private float lastCollectableX;
    private HashSet<string> collectedTypes = new HashSet<string>();
    private GameManager gameManager;
    private bool hasTriggered = false;

    private void Start()
    {
        gameManager = GetComponent<GameManager>();
        float spawnX = player.position.x + startOffset;

        foreach (GameObject prefab in collectablePrefabs)
        {
            Vector3 spawnPos = new Vector3(spawnX, verticalPosition, 0);
            Instantiate(prefab, spawnPos, Quaternion.identity);
            spawnX += spacing;
        }

        lastCollectableX = spawnX - spacing + 10; 
    }

    private void Update()
    {
        if (!hasTriggered && player.position.x > lastCollectableX)
        {
            hasTriggered = true;
            gameManager.OnAllCollectablesFinished();
        }
    }

}
