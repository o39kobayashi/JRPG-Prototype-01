using UnityEngine;
using System.Collections;
using Mono.Cecil.Cil;

public class BattlePlayerTurnState : BattleBaseState {

    private const float PLAYER_WAIT_TIME = 2.0f;
    private bool _enemyIsDead;

    public BattlePlayerTurnState(BattleStateMachine currentContext, BattleStateFactory battleStateFactory)
    : base(currentContext, battleStateFactory) { }

    public override void EnterState()
    {

        Debug.Log("PLAYER TURN");

        Ctx.DialogueText = "YOUR TURN: Choose an Action: ";
    }

    public override void UpdateState()
    {

        if (Ctx.AttackPressed) {

            Ctx.AttackPressed = false;

            Ctx.StartCoroutine(PlayerAttack());
        
        }

    }

    public override void ExitState()
    {
        
    }

    public override void CheckSwitchStates()
    {

        if (_enemyIsDead)
        {
            SwitchState(Factory.Won());

        }
        else {

            SwitchState(Factory.EnemyTurn());
        
        }

    }

    public override void InitializeSubState()
    {
        
    }

    private IEnumerator PlayerAttack() {

        // dmg enemy
        Debug.Log("PLAYER ATTACKED");
        
        _enemyIsDead = Ctx.EnemyUnit.TakeDamage(Ctx.PlayerUnit.Damage);
        Ctx.EnemyHUD.SetHP(Ctx.EnemyUnit.CurrentHP);

        yield return new WaitForSeconds(PLAYER_WAIT_TIME);

        // Check if enemy is dead
        Debug.Log("PLAYER FINISHED ATTACKING");

        CheckSwitchStates();

    }

    
}
