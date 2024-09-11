using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Since the entire pole _is_ the trigger, this line triggers for both
        // the head and the snowboard going through it. It's saying 'what collided with me?'
        // and in this case, it's two separate things, both belonging to the Player.
        if (other.CompareTag("Player")) Debug.Log("Finished!");
    }
}
