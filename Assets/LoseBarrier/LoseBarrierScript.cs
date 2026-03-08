using Unity.Netcode;
using Unity.VisualScripting;
using UnityEditor.Overlays;
using UnityEngine;

public class LoseBarrierScript : NetworkBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
