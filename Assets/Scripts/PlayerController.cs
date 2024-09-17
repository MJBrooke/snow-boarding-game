using UnityEngine;

/// <summary>
/// Handles rotation and boosting of the Snow Boarder
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Tooltip("Amount of rotational force to apply to the player")]
    [SerializeField] private float torqueAmount = 12f;
    
    [Tooltip("Speed of the player when not boosting")]
    [SerializeField] private float baseSpeed = 20f;
    
    [Tooltip("Speed of the player when boosting")]
    [SerializeField] private float boostSpeed = 50f;
    
    private Rigidbody2D _rb;
    private SurfaceEffector2D _surfaceEffector;

    private void Awake()
    {
        // GetComponent fetches a component off of the same GameObject that this script belongs to. Efficient.
        _rb = GetComponent<Rigidbody2D>();
        
        // FindObjectOfType searches the entire scene for an object of the given type. It returns the first instance it finds.
        // Typically slower, since it has to iterate over all GameObjects - O(n) time where n is the number of game objects.
        _surfaceEffector = FindObjectOfType<SurfaceEffector2D>();
    }

    private void Update()
    {
        HandleRotate();
        RespondToBoost();
    }

    private void HandleRotate()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) _rb.AddTorque(torqueAmount);
        else if (Input.GetKey(KeyCode.RightArrow)) _rb.AddTorque(-torqueAmount);
    }

    private void RespondToBoost()
    {
        _surfaceEffector.speed = Input.GetKey(KeyCode.UpArrow) ? boostSpeed : baseSpeed;
    }
    
    // A public function can be directly invoked in other Scripts a line such as the following:
    //  FindObjectOfType<PlayerController>().DisableControls();
    //  This lets you make directly manipulate behaviours via their public methods/API.
    public void DisableControls()
    {
        _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
