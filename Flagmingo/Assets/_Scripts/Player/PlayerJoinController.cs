using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJoinController : MonoBehaviour
{
    [SerializeField] private PlayerSpawn playerSpawn;

    public void OnPlayerJoined()
    {
        Debug.Log($"<color=lime>Player spawned</color>");
        GameObject[] joinedPlayer = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in joinedPlayer)
        {
            if (!playerSpawn.Players.Contains(player))
            {
                playerSpawn.Players.Add(player);
                playerSpawn.MovePlayerToSpawn(player);
                Debug.Log($"Added player {playerSpawn.Players.Count} to the list");
            }
        }
    }

    public void OnPlayerLeft()
    {
        Debug.Log("<color=green>A player left the game</color>");
    }
}
