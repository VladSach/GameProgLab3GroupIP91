using UnityEngine;

public class GameLostState : GameBasicState
{
    public override void EnterState(GameStateManager game)
    {
        game.player.canMove = false;
    }

    public override void UpdateState(GameStateManager game)
    {
        game.SwitchState(game.beginState);
    }
}