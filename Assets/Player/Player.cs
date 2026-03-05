using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public bool isGrounded = false;

    public float moveSpeed = 5f;

    public float rotationSpeed = 100f;

    float rotateInput = 0f;

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
        // For wasd
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        // For jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * 500);
        }

        // For Q and E rotate inputs
        if (Input.GetKey(KeyCode.Q))
        {
            rotateInput = -1f;
        } else if (Input.GetKey(KeyCode.E))
        {
            rotateInput = 1f;
        } else
        {
            rotateInput = 0f;
        }
    }

    private void FixedUpdate()
    {
        // Movement
        rb.AddForce(xInput * moveSpeed, 0, yInput * moveSpeed);

        // Rotation
        if (rotateInput != 0f)
        {
            Quaternion delta = Quaternion.Euler(0f, rotateInput * rotationSpeed * Time.fixedDeltaTime, 0f);
            rb.MoveRotation(rb.rotation * delta);
        }
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
