using UnityEngine;

public class GameBeginState : GameBasicState
{
    public override void EnterState(GameStateManager game)
    {
        game.player.transform.position = new Vector2(-10, -4);
        game.player.canMove = false;
        game.player.Dead = false;
        game.player.Won = false;

        game.prompt.enabled = true;
        game.prompt.text = "Press Space to Begin";
    }

    public override void UpdateState(GameStateManager game)
    {
        if (Input.GetButtonDown("Jump"))
        {
            game.SwitchState(game.playingState);
        }
    }
}
