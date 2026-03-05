using UnityEngine;

public class GroundScript : MonoBehaviour
{
    Vector3 savedRotation;
    void Start()
    {
        savedRotation = transform.eulerAngles;
    }
    void Update()
    {
        // Makes sure rotation moves back to its original
        while (transform.eulerAngles != savedRotation)
        {
            //if (transform.eulerAngles.y == 
        }
    }
}
