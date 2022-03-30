using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJoinController : MonoBehaviour
{
    [SerializeField] private PlayerSpawn playerSpawn;

    public void OnPlayerJoined()
    {
        Debug.Log(Colorize.Spawn($"Player spawned"));

        GameObject[] joinedPlayer = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in joinedPlayer)
        {
            if (!playerSpawn.Players.Contains(player))
            {
                playerSpawn.Players.Add(player);
                playerSpawn.MovePlayerToSpawn(player);

                Debug.Log(Colorize.Player($"Added player {playerSpawn.Players.Count} to the list"));
            }
        }
    }

    public void OnPlayerLeft()
    {
        Debug.Log(Colorize.Player("A player left the game"));
    }
}
