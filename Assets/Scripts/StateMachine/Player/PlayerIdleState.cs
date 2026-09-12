using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{

    public PlayerIdleState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
    : base(currentContext, playerStateFactory) { }

    public override void EnterState() {

        Debug.Log("IDLE STATE");

        /*
        Animator Setup

        _ctx.Animator.SetBool(_ctx.IsWalkingHash, false);
        _ctx.Animator.SetBool(_ctx.IsRunningHash, false);

        */

        Ctx.PlayerMovementX = 0;
        Ctx.PlayerMovementZ = 0;

    }

    public override void UpdateState() {

        CheckSwitchStates();
        
    }

    public override void ExitState() { }

    public override void CheckSwitchStates() {

        if (Ctx.IsMoving && Ctx.IsRunning)
        {

            SwitchState(Factory.Run());

        }
        else if (Ctx.IsMoving) {

            SwitchState(Factory.Walk());
        
        }
    
    }

    public override void InitializeSubState() { }
}