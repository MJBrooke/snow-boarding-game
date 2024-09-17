using UnityEngine;

public class SnowTrail : MonoBehaviour
{
    // We want to control a snow particle behind the board
    //  If we're touching the ground, we should switch on the particles.
    //  When we leave the ground, we turn them off
    
    [SerializeField] private ParticleSystem snowParticles;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")) snowParticles.Play();
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        snowParticles.Stop();
    }
}
