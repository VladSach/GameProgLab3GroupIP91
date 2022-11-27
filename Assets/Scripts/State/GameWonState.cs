using UnityEngine;
public class GameWonState : GameBasicState
{
    public override void EnterState(GameStateManager game)
    {
        game.prompt.enabled = true;
        game.prompt.text = "You Won!";
    }

    public override void UpdateState(GameStateManager game)
    {
        game.player.canMove = false;
    }
}