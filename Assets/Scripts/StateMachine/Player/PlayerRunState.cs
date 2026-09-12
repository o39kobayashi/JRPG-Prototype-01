using UnityEngine;

public class PlayerRunState : PlayerBaseState
{

    public PlayerRunState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
    : base (currentContext, playerStateFactory){ }


    public override void EnterState() {

        Debug.Log("RUNNING STATE");

        /*
        Animator Setup

        _ctx.Animator.SetBool(_ctx.IsWalkingHash, false);
        _ctx.Animator.SetBool(_ctx.IsRunningHash, true);

        */



    }

    public override void UpdateState() {

        CheckSwitchStates();

        Ctx.PlayerMovementX = Ctx.MoveDirectionX * Ctx.RunSpeed;
        Ctx.PlayerMovementZ = Ctx.MoveDirectionZ * Ctx.RunSpeed;

        Quaternion targetRotation = Quaternion.LookRotation(Ctx.TargetDirection);
        Ctx.TransformRotation = Quaternion.Slerp(Ctx.CurrentRotation, targetRotation, Ctx.RotationSpeed * Time.deltaTime);

    }

    public override void ExitState() { }

    public override void CheckSwitchStates() {

        if (!Ctx.IsMoving) {

            SwitchState(Factory.Idle());

        } else if (Ctx.IsMoving && !Ctx.IsRunning){

            SwitchState(Factory.Walk());
        
        }
    
    }

    public override void InitializeSubState() { }
}
