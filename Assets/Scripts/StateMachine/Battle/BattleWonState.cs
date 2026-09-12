using System.Collections;
using UnityEngine;

public class BattleWonState : BattleBaseState
{
    private const float WIN_END_TIMER = 2.0f;

    public BattleWonState(BattleStateMachine currentContext, BattleStateFactory battleStateFactory) 
    : base(currentContext, battleStateFactory) { }

    public override void EnterState()
    {

        Ctx.DialogueText = "You defeated Bobbert!";

        Ctx.StartCoroutine(EndBattle());

    }

    public override void UpdateState()
    {

    }

    public override void ExitState()
    {
        
    }

    public override void CheckSwitchStates()
    {
        
    }

    public override void InitializeSubState()
    {
        
    }

    private IEnumerator EndBattle() {

        yield return new WaitForSeconds(WIN_END_TIMER);

        Debug.Log("END OF THE BATTLE");

        Ctx.InBattle = false;

        Ctx.Player.SetActive(true);
        Ctx.ExploreCamera.SetActive(true);

        Ctx.BattleCamera.SetActive(false);


    }

}
