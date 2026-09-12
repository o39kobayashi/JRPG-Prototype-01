using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private CharacterController characterController;
    [SerializeField] private Transform camera;
    [SerializeField] private float moveSpeed;

    private void Start() {


        characterController = GetComponent<CharacterController>();
    

    }

    public void MovePlayer(Vector2 movementInput) {

        Vector3 moveDirection = (camera.forward * movementInput.y) + (camera.right * movementInput.x);

        moveDirection = moveDirection * moveSpeed;

        characterController.Move(moveDirection * Time.deltaTime);
    
    }



}
