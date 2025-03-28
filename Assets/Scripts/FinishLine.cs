// using UnityEngine;

// public class FinishLine : MonoBehaviour
// {
//     void OnTriggerEnter2D(Collider2D other)
//     {
//         if (other.CompareTag("Player"))
//         {
//             Debug.Log("Level Completed!");

//             PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
//             if (playerMovement != null)
//             {
//                 playerMovement.enabled = false;

//                 Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
//                 if (rb != null)
//                     rb.velocity = Vector2.zero;
//             }
//         }
//     }
// }
