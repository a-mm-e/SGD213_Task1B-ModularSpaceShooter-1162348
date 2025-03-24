using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private float maximumSpinSpeed = 200f;

    // Initialise with a random angular velocity.  
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.angularVelocity = Random.Range(-maximumSpinSpeed, maximumSpinSpeed);
    }
}
