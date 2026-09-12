using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;
using Unity.GraphToolkit.Editor;

public class GameManager : MonoBehaviour
{

    private GameBaseState _currentState;
    private GameStateFactory _states;

    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _exploreSystem;
    [SerializeField] private GameObject _battleSystem;


    private bool _inExplore;
    private bool _inBattle;
    private bool _inMenu;


    public GameBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }
    public GameObject Player { get { return _player; } }
    public GameObject ExploreSystem { get { return _exploreSystem; } }
    public GameObject BattleSystem { get { return _battleSystem; } }
    public bool InExplore { get { return _inExplore; } set { _inExplore = value;} }
    public bool InBattle { get { return _inBattle; } set { _inBattle = value; } }
    public bool InMenu { get { return _inMenu; } set { _inMenu = value; } }


    private void Awake() {

        _inExplore = true;
        _inBattle = false;

        _states = new GameStateFactory(this);
        _currentState = _states.Explore();
        _currentState.EnterState();

    }

    private void Update() {

        // Debug.Log("GAMEMANAGER UPDATE || inBattle = " + _inBattle);
        _currentState.UpdateState();

    }


}
