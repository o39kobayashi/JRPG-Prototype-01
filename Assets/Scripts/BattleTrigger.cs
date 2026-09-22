using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class BattleTrigger : MonoBehaviour
{

    [SerializeField] private GameManager _gameManager;
    [SerializeField] private EnemyManager _enemyManager;

    [SerializeField] private EnemyEncounterData _encounterData;

    private List<CharacterData> _enemies;
    private int _battleArenaID;
    private int _level;

    private void Awake() {

        _enemies = _encounterData.Enemies;
        _battleArenaID = _encounterData.BattleArenaID;
        _level = _encounterData.Level;

    }

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("BATTLE TRIGGERED");


        _gameManager.InBattle = true;
        // enemymanager setsup character classes to be sent to battle state machine
        _enemyManager.ParseEncounterData(_enemies, _battleArenaID, _level);
        gameObject.SetActive(false);

    }

}
