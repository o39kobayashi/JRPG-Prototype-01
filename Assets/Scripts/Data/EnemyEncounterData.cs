using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "EnemyEncounterData", menuName = "Scriptable Objects/EnemyEncounterData")]
public class EnemyEncounterData : ScriptableObject
{

    [SerializeField] private List<CharacterData> _enemies;

    [SerializeField] private string _encounterText;

    [SerializeField] private int _battleArenaID;

    [SerializeField] private int _level;

    public List<CharacterData> Enemies { get { return _enemies; } }
    public string EncounterText { get { return _encounterText; } }
    public int BattleArenaID { get { return _battleArenaID; } }
    public int Level { get { return _level; } }


}

