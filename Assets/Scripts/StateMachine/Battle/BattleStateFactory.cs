using UnityEngine;

public class BattleStateFactory
{

    private BattleStateMachine _context;

    public BattleStateFactory(BattleStateMachine currentContext)
    {
        _context = currentContext;

    }

    public BattleBaseState Start() { return new BattleStartState(_context, this); }
    public BattleBaseState PlayerTurn() { return new BattlePlayerTurnState(_context, this); }
    public BattleBaseState EnemyTurn() { return new BattleEnemyTurnState(_context, this); }
    public BattleBaseState Won() { return new BattleWonState(_context, this); }
    public BattleBaseState Lost() { return new BattleLostState(_context, this);  }


}
