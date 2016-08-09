using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour 
{
    public TouchButton playButton;
    public TouchButton newGameButton;
    public TouchButton quitButton;
    public TextMesh loadingText;
    public Animator loadingAnimator;

	void Start () 
    {
        loadingText.GetComponent<Renderer>().sortingOrder = 3;
	}
	
	void Update () 
    {
	    if(GameController.GameControllerProperties.GetCurrentGameState() == GameState.MENU)
        {
            if(playButton.canDo == 1)
            {
                Invoke("LoadScene", 0.5f);
                loadingAnimator.Play("OpenLoading");

                if (PlayerPrefs.GetInt("Tutorial") == 0)
                {
                    GameController.GameControllerProperties.SetCurrentGameState(GameState.TUTORIAL);
                }

                else
                {
                    GameController.GameControllerProperties.SetCurrentGameState(GameState.PLAY);
                }

                SoundController.PlaySound(SoundState.BUTTON_CLIC);
                playButton.canDo = 0;
            }

            if (newGameButton.canDo == 1)
            {
                PlayerPrefs.DeleteAll();
                Invoke("LoadScene", 0.5f);
                loadingAnimator.Play("OpenLoading");
                GameController.GameControllerProperties.SetCurrentGameState(GameState.TUTORIAL);
                SoundController.PlaySound(SoundState.BUTTON_CLIC);
                newGameButton.canDo = 0;
            }

            if (quitButton.canDo == 1)
            {
                SoundController.PlaySound(SoundState.BUTTON_CLIC);
                Application.Quit();
                quitButton.canDo = 0;
            }
        }
	}

    void LoadScene()
    {
        Application.LoadLevel("Game");
    }
}
