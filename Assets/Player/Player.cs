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

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

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
        // camera relative movement
        Transform cam = Camera.main.transform;

        Vector3 camForward = cam.forward;
        camForward.y = 0;
        camForward.Normalize();

        Vector3 camRight = cam.right;
        camRight.y = 0;
        camRight.Normalize();

        // move based on direction
        Vector3 moveDir = camRight * xInput + camForward * yInput;

        rb.AddForce(moveDir * moveSpeed);

        // when pressing Q or E
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
