public abstract class PlayerBaseState
{
    /*
    protected bool _isRootState = false;
    protected PlayerStateMachine _ctx;
    protected PlayerStateFactory _factory;
    protected PlayerBaseState _currentSuperState;
    protected PlayerBaseState _currentSubState;
    */

    private bool _isRootState = false;
    private PlayerStateMachine _ctx;
    private PlayerStateFactory _factory;
    private PlayerBaseState _currentSuperState;
    private PlayerBaseState _currentSubState;


    protected bool IsRootState { get { return _isRootState; } set { _isRootState = value; } }
    protected PlayerStateMachine Ctx { get { return _ctx; } }
    protected PlayerStateFactory Factory { get { return _factory; } }


    public PlayerBaseState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) {

        _ctx = currentContext;
        _factory = playerStateFactory;
    
    }

    public abstract void EnterState();

    public abstract void UpdateState();

    public abstract void ExitState();

    public abstract void CheckSwitchStates();

    public abstract void InitializeSubState();


    public void UpdateStates() {

        UpdateState();

        if (_currentSubState != null) {

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

    protected void SwitchState(PlayerBaseState newState) {

        // exit current state
        ExitState();

        // new state enters state
        newState.EnterState();

        // switch current state of context (playerstatemachine)
        if (_isRootState) {

            _ctx.CurrentState = newState;

        } else if (_currentSuperState != null) {

            _currentSuperState.SetSubState(newState);
        
        }
    
    }

    protected void SetSuperState(PlayerBaseState newSuperState) {

        _currentSuperState = newSuperState;
    
    }

    protected void SetSubState(PlayerBaseState newSubState) {

        _currentSubState = newSubState;

        newSubState.SetSuperState(this);

    }

}
