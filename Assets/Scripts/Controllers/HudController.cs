using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

[System.Serializable]
public class ButtonsClassHudController
{
    [Header("Butoes HUD")]
    public TouchButton mapButton;
    public TouchButton pauseButton;
    public TouchButton soundButton;
    public TouchButton arrowButton;
    public TouchButton marketButton;
    public TouchButton backButton;
    [Header("Sprite pause")]
    public Sprite playSprite;
    [HideInInspector]
    public Sprite pauseSprite;
}

public class HudController : MonoBehaviour
{
    public ButtonsClassHudController buttonsInstance;
    public Animator marketAnimator;
    public Animator mapAnimator;
    private bool canOpenMarket = true;
    private bool canOpenMap = true;
    private bool isPlaying;
    private float initialAudioVolume;
    public Animator loadingAnimator;
    public GameObject tutorialAnimator;

	void Start () 
    {
        isPlaying = true;
        initialAudioVolume = AudioListener.volume;
        buttonsInstance.pauseSprite = buttonsInstance.pauseButton.GetComponentInChildren<SpriteRenderer>().sprite;
        loadingAnimator.Play("CloseLoading");

        if (PlayerPrefs.GetInt("Tutorial") == 0)
        {
            tutorialAnimator.SetActive(true);
        }

        else
        {
            tutorialAnimator.SetActive(false);
        }
	}
	
	void Update ()
    {
        ButtonsBehaviour();
	}

    void ButtonsBehaviour()
    {
        //botao som
        if (buttonsInstance.soundButton.canDo == 1)
        {
            if (isPlaying)
            {
                AudioListener.volume = 0;
                isPlaying = false;
            }

            else
            {
                AudioListener.volume = initialAudioVolume;
                isPlaying = true;
            }

            SoundController.PlaySound(SoundState.BUTTON_CLIC);
            buttonsInstance.soundButton.canDo = 0;
        }

        //botao pause
        if (buttonsInstance.pauseButton.canDo == 1)
        {
            if(buttonsInstance.pauseButton.GetComponentInChildren<SpriteRenderer>().sprite == buttonsInstance.pauseSprite)
            {
                buttonsInstance.pauseButton.GetComponentInChildren<SpriteRenderer>().sprite = buttonsInstance.playSprite;
            }

            else
            {
                buttonsInstance.pauseButton.GetComponentInChildren<SpriteRenderer>().sprite = buttonsInstance.pauseSprite;
            }

            SoundController.PlaySound(SoundState.BUTTON_CLIC);
            StartCoroutine(PauseOrPlayGame());
            StopCoroutine("PauseOrPlayGame");
            buttonsInstance.pauseButton.canDo = 0;
        }

        if (GameController.GameControllerProperties.GetCurrentGameState() == GameState.PLAY)
        {
            //arrow button
            if (buttonsInstance.arrowButton.canDo == 1)
            {
                if (FindObjectOfType<CameraBehaviour>().cameraRotationId < 3)
                {
                    FindObjectOfType<CameraBehaviour>().cameraRotationId++;
                }

                else if (FindObjectOfType<CameraBehaviour>().cameraRotationId >= 3)
                {
                    FindObjectOfType<CameraBehaviour>().cameraRotationId = 0;
                }

                SoundController.PlaySound(SoundState.BUTTON_CLIC);
                buttonsInstance.arrowButton.canDo = 0;
            }

            //back button
            if (buttonsInstance.backButton.canDo == 1)
            {
                Invoke("LoadScene", 0.5f);
                loadingAnimator.Play("OpenLoading");
                GameController.GameControllerProperties.SetCurrentGameState(GameState.MENU);
                SoundController.PlaySound(SoundState.BUTTON_CLIC);
                buttonsInstance.backButton.canDo = 0;
            }
        }

        //botao mapa
        if (GameController.GameControllerProperties.GetCurrentGameState() == GameState.PLAY
        || GameController.GameControllerProperties.GetCurrentGameState() == GameState.MAP
        || GameController.GameControllerProperties.GetCurrentGameState() == GameState.TUTORIAL)
        {
            if (buttonsInstance.mapButton.canDo == 1)
            {
                if (GameController.GameControllerProperties.GetCurrentGameState() == GameState.PLAY
                || GameController.GameControllerProperties.GetCurrentGameState() == GameState.TUTORIAL)
                {
                    if (PlayerPrefs.GetInt("Tutorial") == 0)
                    {
                        FindObjectOfType<Tutorial>().tutorialId++;
                    }

                    StartCoroutine(OpenOrCloseMapAnimation());
                    GameController.GameControllerProperties.SetCurrentGameState(GameState.MAP);
                }

                else if (GameController.GameControllerProperties.GetCurrentGameState() == GameState.MAP)
                {
                    if (PlayerPrefs.GetInt("Tutorial") == 0)
                    {
                        FindObjectOfType<Tutorial>().tutorialId++;
                    }

                    StartCoroutine(OpenOrCloseMapAnimation());
                    GameController.GameControllerProperties.SetCurrentGameState(GameState.PLAY);
                }

                SoundController.PlaySound(SoundState.BUTTON_CLIC);
                StopCoroutine("OpenOrCloseMapAnimation");
                buttonsInstance.mapButton.canDo = 0;
            }
        }

        if (GameController.GameControllerProperties.GetCurrentGameState() == GameState.PLAY
        || GameController.GameControllerProperties.GetCurrentGameState() == GameState.MARKET
        || GameController.GameControllerProperties.GetCurrentGameState() == GameState.TUTORIAL)
        {
            //Botao Loja
            if (buttonsInstance.marketButton.canDo == 1)
            {
                if (GameController.GameControllerProperties.GetCurrentGameState() == GameState.PLAY)
                {
                    if (PlayerPrefs.GetInt("Tutorial") == 0)
                    {
                        FindObjectOfType<Tutorial>().tutorialId++;
                    }
                }

                else if(GameController.GameControllerProperties.GetCurrentGameState() == GameState.MARKET)
                {
                    if (PlayerPrefs.GetInt("Tutorial") == 0)
                    {
                        tutorialAnimator.SetActive(false);
                        PlayerPrefs.SetInt("Tutorial", 1);
                    }
                }

                SoundController.PlaySound(SoundState.BUTTON_CLIC);
                OpenOrCloseMarketAnimation();
                buttonsInstance.marketButton.canDo = 0;
            } 
        }
    }

	IEnumerator LoadSceneByName(string newScene, GameState newGameState)
	{
		yield return new WaitForSeconds(0.3f);
		Application.LoadLevel(newScene);
		GameController.GameControllerProperties.SetCurrentGameState(newGameState);
	}

    IEnumerator PauseOrPlayGame()
    {
        yield return new WaitForSeconds(0.3f);

        if (GameController.GameControllerProperties.GetCurrentGameState() == GameState.PLAY)
        {
            GameController.GameControllerProperties.SetCurrentGameState(GameState.PAUSE);
        }

        else if (GameController.GameControllerProperties.GetCurrentGameState() == GameState.PAUSE)
        {
            GameController.GameControllerProperties.SetCurrentGameState(GameState.PLAY);
        }
    }

    void OpenOrCloseMarketAnimation()
    {
        if (canOpenMarket)
        {
            if (marketAnimator != null)
            {
                marketAnimator.Play("OpenMarket");
                Camera.main.GetComponent<BlurOptimized>().enabled = true;
            }

            GameController.GameControllerProperties.SetCurrentGameState(GameState.MARKET);
            canOpenMarket = false;
        }

        else
        {
            if (marketAnimator != null)
            {
                marketAnimator.Play("CloseMarket");
                Camera.main.GetComponent<BlurOptimized>().enabled = false;
            }

            GameController.GameControllerProperties.SetCurrentGameState(GameState.PLAY);
            canOpenMarket = true;
        }
    }

    IEnumerator OpenOrCloseMapAnimation()
    {
        yield return new WaitForSeconds(0.3f);

        if (canOpenMap)
        {
            if (mapAnimator != null)
            {
                mapAnimator.Play("OpenMap");
                Camera.main.GetComponent<BlurOptimized>().enabled = true;
            }

            canOpenMap = false;
        }

        else
        {
            if (mapAnimator != null)
            {
                mapAnimator.Play("CloseMap");
                Camera.main.GetComponent<BlurOptimized>().enabled = false;
            }

            canOpenMap = true;
        }
    }

    void LoadScene()
    {
        Application.LoadLevel("Menu");
    }
}
