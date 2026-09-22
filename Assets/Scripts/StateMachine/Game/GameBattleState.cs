using UnityEngine;

public class GameBattleState : GameBaseState
{

    public GameBattleState(GameManager currentContext, GameStateFactory gameStateFactory) 
    : base(currentContext, gameStateFactory) { }

    public override void EnterState() {

        Ctx.ExploreSystem.SetActive(false);
        Ctx.BattleSystem.SetActive(true);
        Ctx.Player.SetActive(false); // will probably need to make this a child of explore system so that dont have to reenable/disable everytime

        Ctx.InExplore = false;
        Ctx.InBattle = true;

    }

    public override void UpdateState() {

        // Debug.Log("GAMEBATTLESTATE UPDATE");

        CheckSwitchState();
    }

    public override void ExitState()
    {
        
    }

    public void CheckSwitchState() {

        if (!Ctx.InBattle) {

            SwitchState(Factory.Explore());

        }
    
    }


}
