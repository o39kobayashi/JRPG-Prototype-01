using UnityEngine;

public abstract class BattleBaseState
{

    private bool _isRootState = false;
    private BattleStateMachine _ctx;
    private BattleStateFactory _factory;
    private BattleBaseState _currentSuperState;
    private BattleBaseState _currentSubState;


    protected bool IsRootState { get { return _isRootState; } set { _isRootState = value; } }
    protected BattleStateMachine Ctx { get { return _ctx; } }
    protected BattleStateFactory Factory { get { return _factory; } }


    public BattleBaseState(BattleStateMachine currentContext, BattleStateFactory playerStateFactory)
    {

        _ctx = currentContext;
        _factory = playerStateFactory;

    }

    public abstract void EnterState();

    public abstract void UpdateState();

    public abstract void ExitState();

    public abstract void CheckSwitchStates();

    public abstract void InitializeSubState();


    public void UpdateStates()
    {

        UpdateState();

        if (_currentSubState != null)
        {

            _currentSubState.UpdateStates();

        }

    }

    /*
    public void ExitStates() {

        ExitState();

        if (_currentSubState != null) {

            _currentSubState.ExitStates();
        
        }
    
    
    }
    */

    protected void SwitchState(BattleBaseState newState)
    {

        // exit current state
        ExitState();

        // new state enters state
        newState.EnterState();

        _ctx.CurrentState = newState;

        // switch current state of context (playerstatemachine)
        // for now i dont think i need substates, just switch between the states based on the conditions
        // but i have a feeling this is going to come back and fuck me in the ass
        /*
        if (_isRootState)
        {

            _ctx.CurrentState = newState;

        }
        else if (_currentSuperState != null)
        {

            _currentSuperState.SetSubState(newState);

        }
        */

    }

    protected void SetSuperState(BattleBaseState newSuperState)
    {

        _currentSuperState = newSuperState;

    }

    protected void SetSubState(BattleBaseState newSubState)
    {

        _currentSubState = newSubState;

        newSubState.SetSuperState(this);

    }

}
