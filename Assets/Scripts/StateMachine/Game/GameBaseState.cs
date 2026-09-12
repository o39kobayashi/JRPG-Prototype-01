using NUnit.Framework;

public abstract class GameBaseState
{

    private bool _isRootState = false;

    private GameManager _ctx;
    private GameStateFactory _factory;

    protected bool IsRootState { get { return _isRootState; } set { _isRootState = value; } }
    protected GameManager Ctx { get { return _ctx; } }
    protected GameStateFactory Factory { get { return _factory; } }

    public GameBaseState(GameManager currentContext, GameStateFactory gameStateFactory) {

        _ctx = currentContext;
        _factory = gameStateFactory;
    
    }

    public abstract void EnterState();

    public abstract void UpdateState();

    public abstract void ExitState();

    protected void SwitchState(GameBaseState newState) {

        ExitState();

        newState.EnterState();

        _ctx.CurrentState = newState;
    
    }





}
