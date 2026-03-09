using Unity.Netcode;
using UnityEngine;

public class LoseBarrierScript : NetworkBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (!IsServer) return;
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
