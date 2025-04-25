using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Scene References")]
    [SerializeField] private GameObject oldBackgroundGroup;
    [SerializeField] private GameObject weddingSceneGroup;
    [SerializeField] private GameObject bride;
    [SerializeField] private Transform venueFocusPoint;

    [Header("Gameplay Components")]
    [SerializeField] private ScreenFade screenFade;
    [SerializeField] private CameraFollow cameraFollow;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private FinalReveal finalReveal;

    private int totalCollectables;
    private int collectedCount;

    private void Start()
    {
       Time.timeScale = 0f;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }


    public void OnAllCollectablesFinished()
    {
        screenFade.FadeInThenOut(OnFadeMidpoint);
    }


    private void OnFadeMidpoint()
    {
        oldBackgroundGroup.SetActive(false);
        weddingSceneGroup.SetActive(true);

        cameraFollow.stopFollowing = true;

        ParallaxLayer[] layers = FindObjectsOfType<ParallaxLayer>();
        foreach (var layer in layers)
        {
            layer.enabled = false;
        }

        Camera cam = Camera.main;
        cam.transform.position = new Vector3(
            venueFocusPoint.position.x,
            cam.transform.position.y,
            cam.transform.position.z
        );

        StartCoroutine(PlacePlayerAfterVenueLoads());
    }

    private IEnumerator PlacePlayerAfterVenueLoads()
    {
        yield return null;

        playerMovement.transform.position = bride.transform.position - new Vector3(3.5f, 0f, 0f);
        playerMovement.moveSpeed = 0f;

        ShowHeart playerHeart = playerMovement.GetComponentInChildren<ShowHeart>();
        ShowHeart brideHeart = bride.GetComponentInChildren<ShowHeart>();

        playerHeart.ShowHeartAfterDelay(1.5f);
        brideHeart.ShowHeartAfterDelay(3f);

        finalReveal.StartFinalReveal();
    }
}
