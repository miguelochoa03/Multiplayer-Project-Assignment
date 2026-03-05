using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public bool isGrounded = false;

    public float moveSpeed = 5f;

    float xInput;
    float yInput;

    Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetMovementInputs();
    }

    void GetMovementInputs()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * 300);
        }

        // Add rotation if I have time and everything is done.
    }

    private void FixedUpdate()
    {
        rb.AddForce(xInput * moveSpeed, 0, yInput * moveSpeed);
    }
    void OnCollisionEnter(Collision collision)
    {
        // When it collides with the ground, sets the variable isGrounded to true
        if (collision.gameObject.name == "Ground")
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        // When it stops colliding with the ground, sets the variable isGrounded to false
        if (collision.gameObject.name == "Ground")
        {
            isGrounded = false;
        }
    }
}
