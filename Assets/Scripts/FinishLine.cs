using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Detects when the player has crossed the finish line
/// </summary>
public class FinishLine : MonoBehaviour
{
    [Tooltip("Sound effect to be played when the player crosses the line")]
    [SerializeField] private AudioSource audioSource; // We can get the AudioSource directly if assigned in the Inspector explicitly.
    
    [Tooltip("Amount of seconds between reaching the finish line and the game restarting")]
    [SerializeField] private float reloadDelay = 2f;
    
    private ParticleSystem _finishDazzle;
    private bool _finished;

    private void Awake()
    {
        _finishDazzle = GetComponentInChildren<ParticleSystem>();
    }

    // Since the entire pole _is_ the trigger, this line triggers for both
    // the head and the snowboard going through it. It's saying 'what collided with me?'
    // and in this case, it's two separate things, both belonging to the Player.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player") || _finished) return;

        _finished = true;
        audioSource.Play(); // The correct AudioClip has already been attached in the Unity editor. We can just play it.
        _finishDazzle.Play();
        Invoke(nameof(ReloadScene), reloadDelay);
    }

    //Wrap static function from SceneManager into a local function for the invoker
    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
