using UnityEngine;

public class GameExploreState : GameBaseState
{

    private GameObject _player;
    private PlayerStateMachine _playerStateMachine;


    public GameExploreState(GameManager currentContext, GameStateFactory gameStateFactory) 
    : base(currentContext, gameStateFactory) { }

    public override void EnterState()
    {

        Debug.Log("GAME_ENTER STATE: Giving control to player");

        // disable non explore systems
        Ctx.BattleSystem.SetActive(false);
        Ctx.InBattle = false;

        // enable explore systems
        Ctx.Player.SetActive(true);
        Ctx.ExploreSystem.SetActive(true);

        Ctx.InExplore = true;

        Debug.Log("GAMEMANAGER INBATTLE: " + Ctx.InBattle);

        _playerStateMachine = Ctx.Player.GetComponent<PlayerStateMachine>();

    }

    public override void UpdateState()
    {
        CheckSwitchState();
    }

    public override void ExitState() { }

    public void CheckSwitchState() {

        if (Ctx.InBattle) {

            // for future debugging purposes, if there are ever weird overlap in states, could be that the substates dont get exited

            SwitchState(Factory.Battle());

        }
    
    }


}
