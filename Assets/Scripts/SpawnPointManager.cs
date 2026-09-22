using UnityEngine;
using System.Collections.Generic;
using System;

public class SpawnPointManager : MonoBehaviour
{

    [Serializable] public struct BattleSpawnLocation {

        [SerializeField] private int _ID;
        [SerializeField] private GameObject _playerBattleSpawnLocation;
        [SerializeField] private GameObject _enemyBattleSpawnLocation;

        public GameObject PlayerBattleSpawnLocation { get { return _playerBattleSpawnLocation; } }
        public GameObject EnemyBattleSpawnLocation { get { return _enemyBattleSpawnLocation; } }

    }

    [SerializeField] private List<BattleSpawnLocation> _allBattleSpawnLocations;

    public List<BattleSpawnLocation> AllBattleSpawnLocations { get { return _allBattleSpawnLocations; } }

    // want to write code that takes in the int instead of just location, keep all spawn logic here, and return proper information to battle state machine

    public List<Transform> GetSpawnPoints(int arenaID, bool forPlayer) {

        List<Transform> spawnPoints = new List<Transform>();
        GameObject spawnLocation;

        if (forPlayer) {

            spawnLocation = _allBattleSpawnLocations[arenaID].PlayerBattleSpawnLocation;

        } else {

            spawnLocation = _allBattleSpawnLocations[arenaID].EnemyBattleSpawnLocation;
        
        }

        foreach (Transform spawnPoint in spawnLocation.transform) {

            spawnPoints.Add(spawnPoint);
        
        }

        Debug.Log("Looped through | arenaID: " + arenaID + " | list size: " + spawnPoints.Count);
        return spawnPoints;
    
    }

    
}
