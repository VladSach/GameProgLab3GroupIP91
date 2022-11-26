using UnityEngine;

public abstract class GameBasicState
{
    public abstract void EnterState(GameStateManager game);

    public abstract void UpdateState(GameStateManager game);
}
