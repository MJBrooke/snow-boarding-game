using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float torqueAmount = 12f;
    [SerializeField] private float baseSpeed = 20f;
    [SerializeField] private float boostSpeed = 50f;
    
    private Rigidbody2D _rb;
    private SurfaceEffector2D _surfaceEffector;

    // A public function can be directly invoked in other Scripts a line such as the following:
    //  FindObjectOfType<PlayerController>().DisableControls();
    // This lets you make directly manipulate behaviours via their public methods/API.
    public void DisableControls()
    {
        _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void Start()
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
}
