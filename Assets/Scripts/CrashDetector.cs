using UnityEngine;

public class CrashDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // This is saying 'has anything collided with my head?'
        // In this case, if it's the ground, we debug out.
        if (other.CompareTag("Ground")) Debug.Log("Bonk!");
    }
}
