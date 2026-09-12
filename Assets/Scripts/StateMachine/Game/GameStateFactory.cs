using UnityEngine;

public class GameStateFactory
{

    private GameManager _context;

    public GameStateFactory(GameManager currentContext) {

        _context = currentContext;

    }

    public GameBaseState Explore() { return new GameExploreState(_context, this);  }

    public GameBaseState Battle() { return new GameBattleState(_context, this);  }

    public GameBaseState Menu() { return new GameMenuState(_context, this); }


}
