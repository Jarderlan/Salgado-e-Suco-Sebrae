using UnityEngine;
using System.Collections;

public enum GameState
{
    MENU,
    PAUSE,
    SETTINGS,
    MARKET,
    SPIN,
	PLAY,
    WAITING,
    MAP,
    SUPERVISOR,
    TUTORIAL,
    GAME_OVER
}

public class GameController 
{
    private static GameState currentGameState = GameState.MENU;
    private static GameController gameControllerInstance = null;

    private GameController()
    {
        Debug.Log(currentGameState);
    }

    public static GameController GameControllerProperties
    {
        get
        {
            if(gameControllerInstance == null)
            {
                gameControllerInstance = new GameController();
            }

            return gameControllerInstance;
        }
    }

	public void SetCurrentGameState (GameState newGameState)
    {
        currentGameState = newGameState;
        Debug.Log(currentGameState);
    }

    public GameState GetCurrentGameState()
    {
        return currentGameState;
    }
}
