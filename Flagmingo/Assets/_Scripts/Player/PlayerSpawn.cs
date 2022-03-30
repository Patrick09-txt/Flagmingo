using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [HideInInspector] public List<GameObject> Players = new List<GameObject>();
    public List<SpawnPoint> AllSpawnPoints = new List<SpawnPoint>();
    
    private List<SpawnPoint> _spawnPointsAvailable = new List<SpawnPoint>();

    private void Awake()
    {
        ResetSpawnPointsAvailable();
    }

    public void MovePlayerToSpawn(GameObject player)
    {
        Debug.Log("Moved player to spawn point: " + _spawnPointsAvailable[0]);

        player.transform.position = _spawnPointsAvailable[0].transform.position;
        _spawnPointsAvailable.Remove(_spawnPointsAvailable[0]);
        _spawnPointsAvailable.TrimExcess();
    }

    public void ResetSpawnPointsAvailable()
    {
        // We can't just set _spawnPointsAvailable = AllSpawnPoints
        // If we do, when we remove spawn points from one, it will remove from the other too
        foreach (SpawnPoint sP in AllSpawnPoints)
        {
            _spawnPointsAvailable.Add(sP);
        }
    }
}
