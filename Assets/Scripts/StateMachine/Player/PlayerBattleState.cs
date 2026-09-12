using UnityEngine;

public class PlayerBattleState : PlayerBaseState
{

    public PlayerBattleState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
    : base(currentContext, playerStateFactory) {

        IsRootState = true;
        InitializeSubState();
    
    }

    public override void EnterState() {

        HandleBattle();
    
    }

    public override void UpdateState() {

        CheckSwitchStates();
    
    }

    public override void ExitState() { }

    public override void CheckSwitchStates() {

        if (!Ctx.InBattle) {

            SwitchState(Factory.Explore());
        
        }
    
    
    }

    public override void InitializeSubState() {


    }

    void HandleBattle() {

        Debug.Log("IN BATTLE STATE");
    
    }

}
