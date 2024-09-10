using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float torqueAmount = 3f;
    
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) _rb.AddTorque(torqueAmount);
        else if (Input.GetKey(KeyCode.RightArrow)) _rb.AddTorque(-torqueAmount);
    }
}
