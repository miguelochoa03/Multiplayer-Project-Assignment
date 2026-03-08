using UnityEngine;

public class ID : MonoBehaviour
{
    public static int nextID = 1;
    public int playerID;

    void Awake()
    {
        playerID = nextID;
        nextID++;

        Debug.Log("Player " + playerID + " Joined");

        GameManager.Instance.RegisterPlayer(this);
    }

    void OnDestroy()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.UnregisterPlayer(this);
    }
}
