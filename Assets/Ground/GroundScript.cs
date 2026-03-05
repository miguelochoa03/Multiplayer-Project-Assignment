using UnityEngine;

public class GroundScript : MonoBehaviour
{

    Rigidbody rb;
    Quaternion originalRot;

    public float returnSpeed = 5f;

    bool isColliding = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalRot = transform.rotation;
    }

    void FixedUpdate()
    {
        // when not colliding, rotate back to its original rotation
        if (!isColliding)
        {
            Quaternion newRot = Quaternion.Slerp(
                rb.rotation,
                originalRot,
                returnSpeed * Time.fixedDeltaTime
            );

            rb.MoveRotation(newRot);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        isColliding = true;
    }

    void OnCollisionStay(Collision collision)
    {
        isColliding = true;
    }

    void OnCollisionExit(Collision collision)
    {
        isColliding = false;
    }
}
