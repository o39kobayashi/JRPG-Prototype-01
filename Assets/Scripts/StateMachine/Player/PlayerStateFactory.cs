using System.Reflection.Metadata.Ecma335;

public class PlayerStateFactory
{

    private PlayerStateMachine _context;

    public PlayerStateFactory(PlayerStateMachine currentContext) {

        _context = currentContext;
    
    }

    public PlayerBaseState Explore() { return new PlayerExploreState(_context, this); }

    public PlayerBaseState Idle() { return new PlayerIdleState(_context, this); }
    public PlayerBaseState Walk() { return new PlayerWalkState(_context, this); }
    public PlayerBaseState Run() { return new PlayerRunState(_context, this); }


    public PlayerBaseState Battle() { return new PlayerBattleState(_context, this); }


}
