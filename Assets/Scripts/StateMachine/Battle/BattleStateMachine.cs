using UnityEngine;
using TMPro;

public class BattleStateMachine : MonoBehaviour
{


    [SerializeField] private GameManager _gameManager;

    private BattleBaseState _currentState;
    private BattleStateFactory _states;

    [SerializeField] private GameObject _player;

    private bool _inExplore;
    private bool _inBattle;

    [SerializeField] private GameObject _exploreCamera;
    [SerializeField] private GameObject _battleCamera;
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform _playerSpawn;
    [SerializeField] private Transform _enemySpawn;


    private GameObject _playerObject;
    private GameObject _enemyObject;
    private Unit _playerUnit;
    private Unit _enemyUnit;

    [SerializeField] private TextMeshProUGUI _dialogue;
    [SerializeField] private BattleHUD _playerHUD;
    [SerializeField] private BattleHUD _enemyHUD;

    private bool _attackPressed;
    private bool _healPressed;

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


    private void Awake() {

    }

    private void OnEnable() {

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


}
