using NUnit.Framework;
using System;
using System.Reflection.Metadata.Ecma335;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class PlayerStateMachine : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private ExploreStateMachine _exploreStateMachine;
    [SerializeField] private Transform _camera;
    [SerializeField] private float _moveSpeed;
    
    private CharacterController _characterController;
    
    private Vector2 _movementInput;
    private Vector3 _playerMovement;
    private Vector3 _moveDirection;

    private Vector3 _targetDirection;

    private Quaternion _currentRotation;

    [SerializeField ]private float _runSpeed = 15.0f;
    [SerializeField] private float _rotationSpeed = 5.0f;

    private Vector3 _cameraForward;
    private Vector3 _cameraRight;

    private bool _inExplore;
    private bool _inBattle;

    private bool _isMoving;
    private bool _isRunning;

    private PlayerBaseState _currentState;
    private PlayerStateFactory _states;

    private const string BATTLE_TRIGGER_TAG = "BattleTrigger";

    [SerializeField] private List<GameObject> _characters;

    private GameObject _activeCharacter;

    private const int REVOLVER_INDEX = 0;
    private const int BLK_MAGE_INDEX = 1;
    private const int SAMURAI_INDEX = 2;
    private const int NO_FACE_INDEX = 3;

    private int _currentCharacterIndex = 0; // may be used if need to remember data across scenes, but not used for now
    private int _activeCharacterIndex;
    private int _partySize;


    // getters and setters
    public CharacterController CharacterController { get { return _characterController; } }
    public PlayerBaseState CurrentState { get { return _currentState; } set { _currentState = value;  } }
    public Transform Transform { get { return transform; } }
    public Quaternion TransformRotation { get { return transform.rotation; } set { transform.rotation = value; } }
    public Transform Camera { get { return _camera; } }
    public Vector2 MovementInput { get { return _movementInput; } set { _movementInput = value; } }
    public Vector3 PlayerMovement { get { return _playerMovement; } }
    public Vector3 CameraForward { get { return _cameraForward; } set { _cameraForward = value; } }
    public Vector3 CameraRight { get { return _cameraRight; } set { _cameraRight = value; } }
    public Vector3 MoveDirection { get { return _moveDirection; } set { _moveDirection = value; } }
    public Vector3 TargetDirection { get { return _targetDirection; } set { _targetDirection = value; } }
    public Quaternion CurrentRotation { get { return _currentRotation; } set { _currentRotation = value; } }
    public float CameraForwardY { set { _cameraForward.y = value; } }
    public float CameraRightY { set { _cameraRight.y = value; } }
    public float MovementInputX { get { return _movementInput.x; } }
    public float MovementInputY { get { return _movementInput.y; } }
    public float PlayerMovementX { get { return _playerMovement.x; } set { _playerMovement.x = value; } }
    public float PlayerMovementY { get { return _playerMovement.y; } set { _playerMovement.y = value; } }
    public float PlayerMovementZ { get { return _playerMovement.z; } set { _playerMovement.z = value; } }
    public float MoveDirectionX { get { return _moveDirection.x; } set { _moveDirection.x = value; } }
    public float MoveDirectionZ { get { return _moveDirection.z; } set { _moveDirection.z = value; } }
    public float TargetDirectionY { get { return _targetDirection.y; } set { _targetDirection.y = value; } }
    public float MoveSpeed { get { return _moveSpeed; } }
    public float RunSpeed { get { return _runSpeed; } }
    public float RotationSpeed { get { return _rotationSpeed; } }
    public bool InExplore { get { return _gameManager.InExplore; } set { _gameManager.InExplore = value; } }
    public bool InBattle { get { return _gameManager.InBattle; }  set { _gameManager.InBattle = value; } }
    public bool IsMoving { get { return _isMoving; } set { _isMoving = value; } }
    public bool IsRunning { get { return _isRunning; } set { _isRunning = value; } }

    public GameObject ActiveCharacter { get { return _activeCharacter; } set { _activeCharacter = value; } }
    public GameObject Character { get { return _characters[_activeCharacterIndex]; } }
    public GameObject Revolver { get { return _characters[REVOLVER_INDEX]; } }
    public GameObject BlkMage { get { return _characters[BLK_MAGE_INDEX]; } }
    public GameObject Samurai { get { return _characters[SAMURAI_INDEX]; } }
    public GameObject NoFace { get { return _characters[NO_FACE_INDEX]; } }
    public int ActiveCharacterIndex { get { return _activeCharacterIndex; } set { _activeCharacterIndex = value; } }
    public int CurrentCharacterIndex { get { return _currentCharacterIndex; } set { _currentCharacterIndex = value; } }
    public int PartySize { get { return _partySize; } }


    private void Awake() {

        _activeCharacterIndex = 0;
        _partySize = _characters.Count; // will cause problems if we dont start with 4 party members, need to figure out other way to count current meembers

        _activeCharacter = _characters[_activeCharacterIndex];
        _activeCharacter.SetActive(true);

        _characterController = _activeCharacter.GetComponent<CharacterController>();

    }

    // need to probably implement OnEnable(), since game will most likely start in a dialogue/cutscene state
    private void OnEnable() {

        _states = new PlayerStateFactory(this);
        _currentState = _states.Explore();
        _currentState.EnterState();

        _gameManager.InExplore = true;
        _gameManager.InBattle = false;

        _cameraForward = _camera.forward;
        _cameraRight = _camera.right;

    }

    private void Start() {

    
    }

    private void Update() {

        _currentState.UpdateStates();
        _characterController.Move(PlayerMovement * Time.deltaTime);

        //upodate party object position so everyone has some position
        transform.position = _activeCharacter.transform.position;

    }

    public void ChangeCharacter() {

        _activeCharacterIndex += 1;

        if (_activeCharacterIndex >= _partySize) {

            _activeCharacterIndex = 0;

        }

        _activeCharacter.SetActive(false);

        _activeCharacter = _characters[_activeCharacterIndex];

        _activeCharacter.SetActive(true);
        _characterController = _activeCharacter.GetComponent<CharacterController>();
    
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag(BATTLE_TRIGGER_TAG)) {

            _gameManager.InBattle = true;
            _gameManager.InExplore = false;

        }

    }


}
