using System.Collections.Generic;
using UnityEngine;

public class PlayerJoinController : MonoBehaviour
{
    [SerializeField] private PlayerSpawn playerSpawn;

    public List<Color> PlayerColors = new List<Color> { Color.red, Color.green, Color.blue, Color.yellow };

    public void OnPlayerJoined()
    {
        Debug.Log(Colorize.Spawn($"Player spawned"));

        GameObject[] joinedPlayer = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in joinedPlayer)
        {
            player.GetComponentInChildren<Player>().Spawn(this);

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
