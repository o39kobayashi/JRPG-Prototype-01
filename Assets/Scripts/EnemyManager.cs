using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{

    private List<Character> _currentEnemies;
    private int _battleArenaID;
    private int _level;

    public List<Character> CurrentEnemies => _currentEnemies;
    public int BattleArenaID { get { return _battleArenaID; } }
    public int Level { get { return _level; } }
    
    public void ParseEncounterData(List<CharacterData> enemies, int battleArenaID, int level) {

        _currentEnemies = new List<Character>();
        _battleArenaID = battleArenaID;
        _level = level;

        foreach (CharacterData enemy in enemies) {

            Character currentEnemy = new Character(enemy, _level);
            _currentEnemies.Add(currentEnemy);

            Debug.Log("Current enemy added to list: " + enemy.Name);
        
        }
    
    }
}
