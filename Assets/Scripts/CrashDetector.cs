using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] private float reloadDelay = 0.5f;
    [SerializeField] private ParticleSystem bloodParticles;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // This is saying 'has anything collided with my head?'
        // In this case, if it's the ground, we restart the level.
        if (!other.CompareTag("Ground")) return;
        
        bloodParticles.Play();
        Invoke(nameof(ReloadScene), reloadDelay);
    }
    
    //Wrap static function from SceneManager into a local function for the invoker
    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
