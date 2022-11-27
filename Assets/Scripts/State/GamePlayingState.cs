using UnityEngine;
public class GamePlayingState : GameBasicState
{
    public override void EnterState(GameStateManager game)
    {
        game.player.canMove = true;
        game.prompt.enabled = false;
    }

    public override void UpdateState(GameStateManager game)
    {
        if (game.player.Dead)
        {
            game.SwitchState(game.lostState);
        }
        else if (game.player.Won)
        {
            game.SwitchState(game.wonState);
        }
    }
}