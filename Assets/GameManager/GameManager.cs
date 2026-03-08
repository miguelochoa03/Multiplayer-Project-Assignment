using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Unity.Netcode;

public class GameManager : NetworkBehaviour
{
    public static GameManager Instance;

    private List<ID> players = new List<ID>();

    public TextMeshProUGUI winnerText;

    void Awake()
    {
        Instance = this;
    }

    public void RegisterPlayer(ID player)
    {
        players.Add(player);
    }

    public void UnregisterPlayer(ID player)
    {
        players.Remove(player);
        if (!IsServer) return;
        CheckForWinner();
    }

    void CheckForWinner()
    {
        if (players.Count == 1)
        {
            int winnerid = players[0].playerID;
            ShowWinnerClientRpc("Player " + winnerid + " Wins!");
        }
        else if (players.Count == 0)
        {
            ShowWinnerClientRpc("No One Survived!");
        }
    }

    [ClientRpc]
    public void ShowWinnerClientRpc(string message)
    {
        winnerText.text = message;
    }
}
