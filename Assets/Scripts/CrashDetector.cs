using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Detects when the player's head hits the ground, restarting the game
/// </summary>
public class CrashDetector : MonoBehaviour
{
    [Tooltip("Time between the crash and the game restarting")]
    [SerializeField] private float reloadDelay = 0.5f;
    
    [Tooltip("The blood particles that should be played on death")]
    [SerializeField] private ParticleSystem bloodParticles;
    
    [Tooltip("The SFX to be played on death")]
    [SerializeField] private AudioClip crashSound; // Direct reference to the Crash+SFX.ogg file
    
    private AudioSource _audioSource; // This audio source has no AudioClip assigned - it's just there to produce the sound we give it in code.
    private bool _hasCrashed;
    
    private void Awake()
    {
        // Get the audio source component attached to the Snow Boarder
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // This is saying 'has anything collided with my head?'
        // In this case, if it's the ground, we restart the level.
        if (!other.CompareTag("Ground") || _hasCrashed) return;
        
        _hasCrashed = true;
        FindObjectOfType<PlayerController>().DisableControls(); // Get a direct reference to the PlayerController class and disable controls
        bloodParticles.Play(); // Manually start the particles when the head hits the floor
        _audioSource.PlayOneShot(crashSound); // Play the crash sound once
        Invoke(nameof(ReloadScene), reloadDelay); // Restart the game after a specified time
    }
    
    //Wrap static function from SceneManager into a local function for the invoker
    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
