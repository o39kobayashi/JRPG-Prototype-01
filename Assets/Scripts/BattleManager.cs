using UnityEngine;

public enum BattleState { START, PLAYER, ENEMY, WON, LOST }


public class BattleManager : MonoBehaviour
{

    private BattleState _state;

    [SerializeField] private GameObject _battleCamera;

    // for testing purposes, will access explorecamera in this script. but when epanding systems, find a better place to enable/disable cameras
    [SerializeField] private GameObject _exploreCamera;

    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private GameObject _enemyPrefab;

    [SerializeField] private Transform _playerSpawn;
    [SerializeField] private Transform _enemySpawn;


    private void Start() {

        //_state = BattleState.START;

        _exploreCamera.SetActive(false);
        _battleCamera.SetActive(true);


        SetupBattle();

    
    }

    private void SetupBattle() {

        GameObject playerObject = Instantiate(_playerPrefab, _playerSpawn);
        GameObject enemyObject = Instantiate(_enemyPrefab, _enemySpawn);
    
    
    }

}
