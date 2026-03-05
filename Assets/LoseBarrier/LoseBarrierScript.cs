using UnityEditor.Overlays;
using UnityEngine;

public class LoseBarrierScript : MonoBehaviour
{
    public GameObject[] spawns;

    void OnCollisionEnter(Collision collision)
    {
        // When the player hits the LoseBarrier
        if (collision.gameObject.name == "Player")
        {
            // Spawn on a random platform
            int randomSpawnIndex = Random.Range(0, spawns.Length);
            collision.transform.position = spawns[randomSpawnIndex].transform.position + new Vector3(0, 10, 0);
        }
    }
}
