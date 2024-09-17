using UnityEngine;

/// <summary>
/// Handles stopping/starting the snow particles left behind after the player rides across the ground
/// </summary>
public class SnowTrail : MonoBehaviour
{
    [Tooltip("The particles that should play while riding across the snow")]
    [SerializeField] private ParticleSystem snowParticles;

    private bool _playEffect = true;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") && _playEffect) snowParticles.Play();
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        snowParticles.Stop();
    }

    public void StopSnowTrail()
    {
        _playEffect = false;
    }
}
