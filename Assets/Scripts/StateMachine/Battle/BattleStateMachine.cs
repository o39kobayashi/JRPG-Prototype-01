using UnityEngine;
using TMPro;
using NUnit.Framework;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Diagnostics.Contracts;

public class BattleStateMachine : MonoBehaviour
{

    [SerializeField] private GameManager _gameManager;
    [SerializeField] private PartyManager _partyManager;
    [SerializeField] private EnemyManager _enemyManager;
    [SerializeField] private SpawnPointManager _spawnPointManager;

    private BattleBaseState _currentState;
    private BattleStateFactory _states;

    [SerializeField] private GameObject _player;

    private bool _inExplore;
    private bool _inBattle;

    [SerializeField] private List<GameObject> _battleArenas;
    private GameObject _currentBattleArena;
    private List<Transform> _playerSpawnPoints;
    private List<Transform> _enemySpawnPoints;


    [SerializeField] private GameObject _exploreCamera;
    [SerializeField] private GameObject _battleCamera;
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform _playerSpawn;
    [SerializeField] private Transform _enemySpawn;

    private Queue<BattleUnit> _unitQueue;

    private List<Character> _battleCharacters;
    private List<Character> _battleEnemies;

    private List<BattleUnit> _battleUnits;

    private GameObject _playerObject;
    private GameObject _enemyObject;
    private Character _playerCharacter;
    private Character _enemyCharacter;
    private BattleUnit _playerBattleUnit;
    private BattleUnit _enemyBattleUnit; // figure out how to incorporate character and battle unit classes into battle system before implementing list
    private Unit _playerUnit;
    private Unit _enemyUnit;

    [SerializeField] private GameObject _targetMarker;

    [SerializeField] private TextMeshProUGUI _dialogue;
    [SerializeField] private BattleHUD _playerHUD;
    [SerializeField] private BattleHUD _enemyHUD;

    private bool _attackPressed;
    private bool _healPressed;

    private const bool FOR_PLAYER = true;


    public BattleBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }
    public GameObject Player { get { return _player; } }
    public GameObject PlayerPrefab { get { return _playerPrefab; } }
    public GameObject EnemyPrefab { get { return _enemyPrefab; } }
    public GameObject PlayerObject { get { return _playerObject; } set { _playerObject = value; } }
    public GameObject EnemyObject { get { return _enemyObject; } set { _enemyObject = value; } }
    public GameObject ExploreCamera { get { return _exploreCamera; } }
    public GameObject BattleCamera { get { return _battleCamera; } }
    public Unit PlayerUnit { get { return _playerUnit; } set { _playerUnit = value; } }
    public Unit EnemyUnit { get { return _enemyUnit; } set { _enemyUnit = value; } }
    public BattleHUD PlayerHUD { get { return _playerHUD; } }
    public BattleHUD EnemyHUD { get { return _enemyHUD; } }
    public Transform PlayerSpawnPoint { get { return _playerSpawn; } }
    public Transform EnemySpawnPoint { get { return _enemySpawn; } }
    public string DialogueText { set { _dialogue.text = value; } }
    public bool InExplore { get { return _gameManager.InExplore; } set { _gameManager.InExplore = value; } }
    public bool InBattle { get { return _gameManager.InBattle; } set { _gameManager.InBattle = value; } }
    public bool AttackPressed { get { return _attackPressed; } set { _attackPressed = value; } }
    public bool HealPressed { get { return _healPressed; } set { _healPressed = value; } }

    public List<Character> BattleCharacters { get { return _battleCharacters; } }
    public List<Character> BattleEnemies { get { return _battleEnemies; } }
    public List<BattleUnit> BattleUnits { get { return _battleUnits; } }
    public Queue<BattleUnit> UnitQueue { get { return _unitQueue; } }
    
    public Character PlayerCharacter { get { return _playerCharacter; } }
    public Character EnemyCharacter { get { return _enemyCharacter; } }
    public BattleUnit PlayerBattleUnit { get { return _playerBattleUnit; } set { _playerBattleUnit = value; } }
    public BattleUnit EnemyBattleUnit { get { return _enemyBattleUnit; } set { _enemyBattleUnit = value; } }

    public GameObject CurrentBattleArena { get { return _currentBattleArena; } }
    public GameObject TargetMarker { get { return _targetMarker; } }

    public string EncounterText { get { return _enemyManager.EncounterText; } }
    public int BattleArenaID { get { return _enemyManager.BattleArenaID; } }
    public List<Transform> PlayerSpawnPoints { get { return _playerSpawnPoints; } }
    public List<Transform> EnemySpawnPoints { get { return _enemySpawnPoints; } }


    private void Awake() {

    }

    private void OnEnable() {

        // create list of battle units
        _unitQueue = new Queue<BattleUnit>();
        _battleUnits = new List<BattleUnit>();
        
        // whenever battlestatemachine is enabled, get active party members from partymanager
        _battleCharacters = _partyManager.ActiveParty;
        DebugPrintCharacterNames(_battleCharacters);
        
        // get enemies from enemy manager
        _battleEnemies = _enemyManager.CurrentEnemies;
        DebugPrintCharacterNames(_battleEnemies);
        
        // current battle arena
        _currentBattleArena = _battleArenas[_enemyManager.BattleArenaID];

        // get spawnpoints of respective battle arena for player and enemies
        
        // _playerSpawnPoints = _spawnPointManager.AllBattleSpawnLocations[_enemyManager.BattleArenaID].GetSpawnPoints(_spawnPointManager.AllBattleSpawnLocations.PlayerBattleSpawnLocation);
        // _playerSpawnPoints = _spawnPointManager.GetSpawnPoints(_spawnPointManager.AllBattleSpawnLocations[_enemyManager.BattleArenaID].PlayerBattleSpawnLocation);
        // _enemySpawnPoints = _spawnPointManager.GetSpawnPoints(_spawnPointManager.AllBattleSpawnLocations[_enemyManager.BattleArenaID].EnemyBattleSpawnLocation);

        _playerSpawnPoints = _spawnPointManager.GetSpawnPoints(_enemyManager.BattleArenaID, FOR_PLAYER);
        _enemySpawnPoints = _spawnPointManager.GetSpawnPoints(_enemyManager.BattleArenaID, !FOR_PLAYER);

        // test
        _playerCharacter = _partyManager.Revolver;
        _enemyCharacter = _partyManager.Enemy;
        /////////

        _states = new BattleStateFactory(this);
        _currentState = _states.Start();
        _currentState.EnterState();

    }

    private void Start() { 
    
    
    
    
    }

    private void Update() {

        //Debug.Log("BATTLESTATEMACHINE | inBattle: " + _gameManager.InBattle);
        _currentState.UpdateStates();
    
    
    }

    public void OnAttack() {

        _attackPressed = true;
    
    }

    public void OnHeal() { 
    
    
    
    }

    private void FindSpawnPoints() {


        
    
    
    }

    private void DebugPrintCharacterNames(List<Character> characters) {

        foreach (Character character in characters) {

            Debug.Log("NAME: " + character.Name);
        
        }
    
    
    }


}
