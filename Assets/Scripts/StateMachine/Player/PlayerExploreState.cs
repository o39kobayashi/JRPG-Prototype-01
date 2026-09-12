using UnityEngine;

public class PlayerExploreState : PlayerBaseState
{

    public PlayerExploreState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
    : base(currentContext, playerStateFactory) {

        IsRootState = true;
        InitializeSubState();

    }

    public override void EnterState() {

        Debug.Log("IN THE EXPLORING STATE");

    }

    public override void UpdateState() {

        CheckSwitchStates();

        ManageCameraVectors();

        HandleMovement();

        HandleRotation();

        HandleGravity();

    }

    public override void ExitState() { }

    public override void CheckSwitchStates() {

        // if player enters fight, enter battle state
        if (Ctx.InBattle) {

            SwitchState(Factory.Battle());

        }

    }

    public override void InitializeSubState() {

        if (!Ctx.IsMoving && !Ctx.IsRunning) {

            SetSubState(Factory.Idle());

        } else if (Ctx.IsMoving && !Ctx.IsRunning) {

            SetSubState(Factory.Walk());

        } else {

            SetSubState(Factory.Run());

        }

    }

    private void ManageCameraVectors() {

        Ctx.CameraForward = Ctx.Camera.forward;
        Ctx.CameraRight = Ctx.Camera.right;

        Ctx.CameraForwardY = 0.0f;
        Ctx.CameraRightY = 0.0f;

        Ctx.CameraForward.Normalize();
        Ctx.CameraRight.Normalize();

    }

    private void HandleMovement() {

        Ctx.MoveDirection = (Ctx.CameraForward * Ctx.MovementInputY) + (Ctx.CameraRight * Ctx.MovementInputX);

        if (Ctx.MovementInputX != 0.0f || Ctx.MovementInputY != 0.0f) {

            Ctx.IsMoving = true;

        } else {

            Ctx.IsMoving = false;

        }

    }

    private void HandleRotation() {

        // Ctx.TargetDirection = (Ctx.CameraForward * Ctx.PlayerMovementZ) + (Ctx.CameraRight * Ctx.PlayerMovementX);
        Ctx.TargetDirection = (Ctx.CameraForward * Ctx.MovementInputY) + (Ctx.CameraRight * Ctx.MovementInputX);

        Ctx.TargetDirectionY = 0.0f;

        Ctx.CurrentRotation = Ctx.TransformRotation;
    
    }

    private void HandleGravity() {

        if (Ctx.CharacterController.isGrounded) {

            float groundedGravity = 0.05f;
            Ctx.PlayerMovementY = groundedGravity;

        } else {

            float gravity = -4.9f;
            Ctx.PlayerMovementY += gravity;
        
        }
    
    }

}
