using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{

    private PlayerMovement playerMovement;

    [SerializeField] private InputActionAsset inputActions;
    private InputAction movementAction;


    private Vector2 movementInput;


    private const string PLAYER_MAP = "Player";
    private const string MOVEMENT_ACTION = "Movement";


    private void Awake() {


        movementAction = inputActions.FindAction(MOVEMENT_ACTION);

        movementAction.started += OnMovementInput;
        movementAction.performed += OnMovementInput;
        movementAction.canceled += OnMovementInput;
    
    
    }

    private void Start() {


        playerMovement = GetComponent<PlayerMovement>();
      
    
    }

    private void Update() {


        playerMovement.MovePlayer(movementInput);
    
    
    }

    private void OnMovementInput(InputAction.CallbackContext context) {

        movementInput = context.ReadValue<Vector2>();
    
    }

    private void OnEnable() => inputActions.FindActionMap(PLAYER_MAP).Enable();

    private void OnDisable() => inputActions.FindActionMap(PLAYER_MAP).Disable();


}
