using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJoinController : MonoBehaviour
{
    public List<GameObject> players = new List<GameObject>();
    public List<SpawnPoint> spawnPointsAvailable = new List<SpawnPoint>();

    public void OnPlayerJoined()
    {
        Debug.Log($"<color=lime>Player spawned</color>");
        GameObject[] joinedPlayer = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in joinedPlayer)
        {
            if (!players.Contains(player))
            {
                players.Add(player);
                MovePlayerToSpawn(player);
                Debug.Log($"Added player {players.Count} to the list");
            }
        }
    }

    public void OnPlayerLeft()
    {
        Debug.Log("<color=green>A player left the game</color>");
    }

    private void MovePlayerToSpawn(GameObject player)
    {
        Debug.Log("Moved player to spawn point: " + spawnPointsAvailable[0]);

        player.transform.position = spawnPointsAvailable[0].transform.position;
        spawnPointsAvailable.Remove(spawnPointsAvailable[0]);
        spawnPointsAvailable.TrimExcess();
    }
}
