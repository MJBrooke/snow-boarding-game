using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource; // We can get the AudioSource directly if assigned in the Inspector explicitly.
    [SerializeField] private float reloadDelay = 2f;
    private ParticleSystem _finishDazzle;

    private void Start()
    {
        _finishDazzle = GetComponentInChildren<ParticleSystem>();
    }

    // Since the entire pole _is_ the trigger, this line triggers for both
    // the head and the snowboard going through it. It's saying 'what collided with me?'
    // and in this case, it's two separate things, both belonging to the Player.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        
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
