using UnityEngine;
using TMPro;
using System.Collections;

public class BattleStartState : BattleBaseState
{

    private const float WAIT_TIMER = 2.0f;

    public BattleStartState(BattleStateMachine currentContext, BattleStateFactory battleStateFactory)
    : base(currentContext, battleStateFactory) { }


    public override void EnterState() {

        Ctx.Player.SetActive(false);
        Ctx.ExploreCamera.SetActive(false);

        Ctx.BattleCamera.SetActive(true);

        Ctx.StartCoroutine(SetupBattle());

    }

    public override void UpdateState()
    {
        
    }

    public override void ExitState()
    {

    }

    public override void CheckSwitchStates() {

        

    }

    public override void InitializeSubState()
    {
        
    }

    private IEnumerator SetupBattle()
    {

        Ctx.PlayerObject = GameObject.Instantiate(Ctx.PlayerPrefab, Ctx.PlayerSpawnPoint);
        Ctx.PlayerUnit = Ctx.PlayerObject.GetComponent<Unit>();

        Ctx.EnemyObject = GameObject.Instantiate(Ctx.EnemyPrefab, Ctx.EnemySpawnPoint);
        Ctx.EnemyUnit = Ctx.EnemyObject.GetComponent<Unit>();

        Ctx.DialogueText = Ctx.EnemyUnit.Name + " approaches, and this guy looks pissed!";

        Ctx.PlayerHUD.SetHUD(Ctx.PlayerUnit);
        Ctx.EnemyHUD.SetHUD(Ctx.EnemyUnit);

        yield return new WaitForSeconds(WAIT_TIMER);

        SwitchState(Factory.PlayerTurn());

    }
}
