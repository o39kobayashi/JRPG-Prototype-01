using UnityEngine;
using System.Collections;

public class BattleEnemyTurnState : BattleBaseState {

    private bool _playerIsDead;
    private const float ENEMY_WAIT_TIME = 2.0f;

    public BattleEnemyTurnState(BattleStateMachine currentContext, BattleStateFactory battleStateFactory)
    : base(currentContext, battleStateFactory) { }

    public override void EnterState()
    {

        Debug.Log("ENEMY TURN");

        Ctx.DialogueText = "Bobbert attacks!";

        Ctx.StartCoroutine(EnemyAttack());

    }

    public override void UpdateState()
    {
        
    }

    public override void ExitState()
    {
        
    }

    public override void CheckSwitchStates()
    {

        if (_playerIsDead) {


            SwitchState(Factory.Lost());
        
        
        } else {

            SwitchState(Factory.PlayerTurn());

        }
        

    }

    public override void InitializeSubState()
    {
        
    }

    private IEnumerator EnemyAttack() {

        yield return new WaitForSeconds(ENEMY_WAIT_TIME);

        // _playerIsDead = Ctx.PlayerUnit.TakeDamage(Ctx.EnemyUnit.Damage);
        _playerIsDead = Ctx.PlayerBattleUnit.TakeDamage(Ctx.EnemyBattleUnit.AttackDamage);

        // Ctx.PlayerHUD.SetHP(Ctx.PlayerUnit.CurrentHP);
        Ctx.PlayerHUD.SetHP(Ctx.PlayerBattleUnit.CurrentHP);

        CheckSwitchStates();

    
    }


    
}
