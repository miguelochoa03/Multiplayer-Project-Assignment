using System.Globalization;
using System.Linq;
using Unity.Netcode;
using UnityEngine;

public class EnemyScript : NetworkBehaviour
{
    public float speed = 5f;

    void Update()
    {
        if (!IsServer) return;

        Transform nearest = GetNearestPlayer();
        if (nearest == null) return;

        transform.position = Vector3.MoveTowards(
            transform.position,
            nearest.position,
            speed * Time.deltaTime
        );
    }

    Transform GetNearestPlayer()
    {
        var players = FindObjectsOfType<Player>();

        if (players.Length == 0)
            return null;

        Player nearest = players
            .OrderBy(p => Vector3.Distance(transform.position, p.transform.position))
            .First();

        return nearest.transform;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!IsServer) return;
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }

}
