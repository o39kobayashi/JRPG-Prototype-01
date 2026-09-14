using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    [SerializeField] private InputActionAsset _inputActions;
    [SerializeField] private PlayerStateMachine _playerStateMachine;
    [SerializeField] private CameraController _cameraController;

    private InputAction _explore_movementAction;
    private InputAction _explore_runAction;
    private InputAction _explore_cameraAction;
    private InputAction _explore_changeCharacter;

    private Vector2 _movementInput;
    private Vector2 _cameraInput;
    private bool _isRunning;

    private const string EXPLORE_PLAYER_MAP = "Explore_Player";
    private const string EXPLORE_MOVEMENT_ACTION = "Explore_Movement";
    private const string EXPLORE_RUN_ACTION = "Explore_Run";
    private const string EXPLORE_CAMERA_ACTION = "Explore_Camera";
    private const string EXPLORE_CHANGE_CHARACTER = "Explore_Change_Character";

    public Vector2 MovementInput { get { return _movementInput; } }
    public bool IsRunning { get { return _isRunning; } }

    private void Awake() {

        _explore_movementAction = _inputActions.FindAction(EXPLORE_MOVEMENT_ACTION);

        _explore_movementAction.started += OnMovementInput;
        _explore_movementAction.performed += OnMovementInput;
        _explore_movementAction.canceled += OnMovementInput;

        _explore_runAction = _inputActions.FindAction(EXPLORE_RUN_ACTION);

        _explore_runAction.started += OnRunInput;
        _explore_runAction.canceled += OnRunInput;

        _explore_cameraAction = _inputActions.FindAction(EXPLORE_CAMERA_ACTION);

        _explore_cameraAction.performed += OnCameraInput;

        _explore_changeCharacter = _inputActions.FindAction(EXPLORE_CHANGE_CHARACTER);

        _explore_changeCharacter.performed += OnChangeCharacter;

    }

    private void OnMovementInput(InputAction.CallbackContext context)
    {

        _movementInput = context.ReadValue<Vector2>();
        _playerStateMachine.MovementInput = MovementInput;
        
    }

    private void OnRunInput(InputAction.CallbackContext context) {

        _isRunning = context.ReadValueAsButton();
        _playerStateMachine.IsRunning = IsRunning;

    }

    private void OnCameraInput(InputAction.CallbackContext context) {

        _cameraInput = context.ReadValue<Vector2>();

        _cameraController.CameraHorizontalInput = _cameraInput.x;
        _cameraController.CameraVerticalInput = _cameraInput.y * -1.0f;
    
    }

    private void OnChangeCharacter(InputAction.CallbackContext context) {

        _playerStateMachine.ChangeCharacter();
    
    }

    private void OnEnable() => _inputActions.FindActionMap(EXPLORE_PLAYER_MAP).Enable();

    private void OnDisable() => _inputActions.FindActionMap(EXPLORE_PLAYER_MAP).Disable();

}
