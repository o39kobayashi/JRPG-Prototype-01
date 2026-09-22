using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SpawnPointData", menuName = "Scriptable Objects/SpawnPointData")]
public class SpawnPointData : ScriptableObject
{

    [SerializeField] private List<GameObject> _townSpawnPoints;
    [SerializeField] private List<GameObject> _allPlayerSpawnPoints;
    [SerializeField] private List<GameObject> _allEnemySpawnPoints;

}
