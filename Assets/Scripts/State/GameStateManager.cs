using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStateManager : MonoBehaviour
{
    GameBasicState currentState;
    public GameBeginState beginState = new GameBeginState();
    public GamePlayingState playingState = new GamePlayingState();
    public GameWonState wonState = new GameWonState();
    public GameLostState lostState = new GameLostState();

    public PlayerMovement player;
    public TextMeshProUGUI prompt;

    void Start()
    {
        currentState = beginState;

        currentState.EnterState(this);
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(GameBasicState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
