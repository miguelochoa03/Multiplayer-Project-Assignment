using System;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponKnockback : MonoBehaviour
{
    [SerializeField] float knockbackForce = 800f;
    void OnCollisionEnter(Collision collision)
    {
        //if (!IsServer) return; // server?authoritative physics only

        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRb = collision.rigidbody;
            if (playerRb == null) return;

            Vector3 hitDirection = (collision.transform.position - transform.position).normalized;
            hitDirection.y = 0.5f;

            playerRb.AddForce(hitDirection * knockbackForce, ForceMode.Impulse);
        }
    }
}
