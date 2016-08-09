using UnityEngine;
using System.Collections;

[System.Serializable]
public class LocksClass
{
    public GameObject[] locks;
}

public class LevelController : MonoBehaviour
{
    public float score;

    [Header("Tempo Salvar")]

    [Header("Salvar Jogo")]
    private float currentTimeToSave;
    private float timeToSave;

    [Header("Fases Bloqueadas")]
    public LocksClass locksInstance;
    [HideInInspector]
    public float currentTime;
    public float levelTime;
    private int getInitialLevelId;
    [Header("Tempo de jogo")]
    [HideInInspector]
    public float countMinutes;
    public float countSeconds;

    [Header("Telas Vitoria/Derrota")]
    public GameObject winObjects;
    public GameObject loseObjects;

    [Header("Botoes Reiniciar/Avancar/Voltar")]
    public TouchButton nextButtonWin;
    public TouchButton restartButtonWin;
    public TouchButton backButtonWin;
    public TouchButton restartButtonLose;
    public TouchButton backButtonLose;

    [Header("Valor legalizar negocio e tempo chamar fiscal")]
    public float cnpjValue;
    public float timeToCallSupervisor;
    public GameObject supervisorObjects;
    [Header("Botao Supervisor")]
    public TouchButton supervisorButton;
    [Header("Problemas de manutencao")]
    public GameObject fixObjects;
    public GameObject guiLose;

    void Start()
    {
        if (fixObjects != null)
        {
            fixObjects.SetActive(false);
        }

        if (supervisorObjects != null)
        {
            supervisorObjects.SetActive(false);
        }

        getInitialLevelId = PlayerPrefs.GetInt("LevelId");
        winObjects.SetActive(false);
        loseObjects.SetActive(false);
        LocksBehaviour();
        LevelTime();
        levelTime *= 60;
        countMinutes = levelTime / 60;

        PlayerPrefs.SetInt("CountProblem", PlayerPrefs.GetInt("CountProblem") + 1);

        //problemas
        if (PlayerPrefs.GetInt("CountProblem") >= 5)
        {
            CallProblems();
            PlayerPrefs.SetInt("CountProblem", 0);
        }
    }

    public void ApplyFixProblem(float fixValue, int fixGuiIndex)
    {
        if (fixObjects != null)
        {
            fixObjects.SetActive(true);
        }

        FindObjectOfType<GUI>().ShowFixProblem(fixGuiIndex);

        ScoreCounter.ScoreCounterProperties.SetCaixaNegative(fixValue);
    }

    void TurOffSound()
    {
        AudioListener.volume = 0f;
    }

    void Update()
    {
        ButtonsBehaviour();
        currentTimeToSave += Time.deltaTime;

        if (currentTimeToSave > timeToSave)
        {
            //salvar na nuvem
            currentTimeToSave = 0;
        }

        if (GameController.GameControllerProperties.GetCurrentGameState() == GameState.PLAY)
        {
            currentTime += Time.deltaTime;
            countSeconds -= Time.deltaTime;

            if(countSeconds <= 0)
            {
                countMinutes--;
                countSeconds = 60;
            }

            //caixa prox nivel
            PlayerPrefs.SetFloat("Caixa", ScoreCounter.ScoreCounterProperties.GetCurrentCaixa());

            //chama supervisor level 5
            if (PlayerPrefs.GetInt("CallSupervisor") == 0 && PlayerPrefs.GetInt("LevelId") == 4)
            {
                if (currentTime > timeToCallSupervisor)
                {
                    if (supervisorObjects != null)
                    {
                        supervisorObjects.SetActive(true);
                    }

                    GameController.GameControllerProperties.SetCurrentGameState(GameState.SUPERVISOR);
                    timeToCallSupervisor = 0;
                    PlayerPrefs.SetInt("CallSupervisor", 1);
                }
            }

            //vitoria
            if (currentTime > levelTime)
            {
                //if (ScoreCounter.ScoreCounterProperties.GetCurrentCaixa() >= ScoreCounter.ScoreCounterProperties.GetInitialMetaMensal())
                if (score >= ScoreCounter.ScoreCounterProperties.GetInitialMetaMensal())
                {
                    GameController.GameControllerProperties.SetCurrentGameState(GameState.GAME_OVER);
                    winObjects.SetActive(true);
                }

                //derrota
                else
                {
                    GameController.GameControllerProperties.SetCurrentGameState(GameState.GAME_OVER);
                    loseObjects.SetActive(true);
                }

                Invoke("TurOffSound", 3.2f);
                guiLose.SetActive(true);
            }
        }

        if(GameController.GameControllerProperties.GetCurrentGameState()== GameState.SUPERVISOR)
        {
            //botao supervisor
            if(supervisorButton.canDo == 1)
            {
                SupervisorBehaviour(cnpjValue);
                StartCoroutine(HideSupervisor());
                StopCoroutine("CloseSupervisor");
                GameController.GameControllerProperties.SetCurrentGameState(GameState.PLAY);
                supervisorButton.canDo = 0;
            }
        }
    }
    void LocksBehaviour()
    {
        //level 2
        if (PlayerPrefs.GetInt("LevelId") == 1)
        {
            locksInstance.locks[0].SetActive(false);
        }

        //level 3
        if (PlayerPrefs.GetInt("LevelId") == 2)
        {
            locksInstance.locks[0].SetActive(false);
            locksInstance.locks[1].SetActive(false);
        }

        //level 4
        if (PlayerPrefs.GetInt("LevelId") == 3)
        {
            locksInstance.locks[0].SetActive(false);
            locksInstance.locks[1].SetActive(false);
            locksInstance.locks[2].SetActive(false);
        }

        //level 5
        if (PlayerPrefs.GetInt("LevelId") == 4)
        {
            locksInstance.locks[0].SetActive(false);
            locksInstance.locks[1].SetActive(false);
            locksInstance.locks[2].SetActive(false);
            locksInstance.locks[3].SetActive(false);
        }

        //level 6
        if (PlayerPrefs.GetInt("LevelId") == 5)
        {
            locksInstance.locks[0].SetActive(false);
            locksInstance.locks[1].SetActive(false);
            locksInstance.locks[2].SetActive(false);
            locksInstance.locks[3].SetActive(false);
            locksInstance.locks[4].SetActive(false);
        }

        //level 7
        if (PlayerPrefs.GetInt("LevelId") == 6)
        {
            locksInstance.locks[0].SetActive(false);
            locksInstance.locks[1].SetActive(false);
            locksInstance.locks[2].SetActive(false);
            locksInstance.locks[3].SetActive(false);
            locksInstance.locks[4].SetActive(false);
            locksInstance.locks[5].SetActive(false);
        }

        //level 8
        if (PlayerPrefs.GetInt("LevelId") == 7)
        {
            locksInstance.locks[0].SetActive(false);
            locksInstance.locks[1].SetActive(false);
            locksInstance.locks[2].SetActive(false);
            locksInstance.locks[3].SetActive(false);
            locksInstance.locks[4].SetActive(false);
            locksInstance.locks[5].SetActive(false);
            locksInstance.locks[6].SetActive(false);
        }

        //level 9
        if (PlayerPrefs.GetInt("LevelId") == 8)
        {
            locksInstance.locks[0].SetActive(false);
            locksInstance.locks[1].SetActive(false);
            locksInstance.locks[2].SetActive(false);
            locksInstance.locks[3].SetActive(false);
            locksInstance.locks[4].SetActive(false);
            locksInstance.locks[5].SetActive(false);
            locksInstance.locks[6].SetActive(false);
            locksInstance.locks[7].SetActive(false);
        }

        //level 10
        if (PlayerPrefs.GetInt("LevelId") == 9)
        {
            locksInstance.locks[0].SetActive(false);
            locksInstance.locks[1].SetActive(false);
            locksInstance.locks[2].SetActive(false);
            locksInstance.locks[3].SetActive(false);
            locksInstance.locks[4].SetActive(false);
            locksInstance.locks[5].SetActive(false);
            locksInstance.locks[6].SetActive(false);
            locksInstance.locks[7].SetActive(false);
            locksInstance.locks[8].SetActive(false);
        }
    }

    void LevelTime()
    {
        if (PlayerPrefs.GetInt("LevelId") == 0)
        {
            levelTime = 5;
        }

        if (PlayerPrefs.GetInt("LevelId") == 1)
        {
            levelTime = 7;
        }

        if (PlayerPrefs.GetInt("LevelId") == 2)
        {
            levelTime = 10;
        }

        if (PlayerPrefs.GetInt("LevelId") == 3)
        {
            levelTime = 15;
        }

        if (PlayerPrefs.GetInt("LevelId") == 4)
        {
            levelTime = 20;
        }

        if (PlayerPrefs.GetInt("LevelId") == 5)
        {
            levelTime = 25;
        }

        if (PlayerPrefs.GetInt("LevelId") == 6)
        {
            levelTime = 30;
        }

        if (PlayerPrefs.GetInt("LevelId") == 7)
        {
            levelTime = 30;
        }

        if (PlayerPrefs.GetInt("LevelId") == 8)
        {
            levelTime = 30;
        }

        if (PlayerPrefs.GetInt("LevelId") == 9)
        {
            levelTime = 30;
        }
    }

    void ButtonsBehaviour()
    {
        if (GameController.GameControllerProperties.GetCurrentGameState() == GameState.GAME_OVER)
        {
            //botoes Win
            if (nextButtonWin.canDo == 1)
            {
                PlayerPrefs.SetInt("LevelId", PlayerPrefs.GetInt("LevelId") + 1);
                StartCoroutine(LoadSceneByName("Game", GameState.PLAY));
                StopCoroutine("LoadSceneByName");
                Debug.Log("Foi");
                nextButtonWin.canDo = 0;
            }

            if (restartButtonWin.canDo == 1)
            {
                PlayerPrefs.SetInt("LevelId", getInitialLevelId);
                StartCoroutine(LoadSceneByName("Game", GameState.PLAY));
                StopCoroutine("LoadSceneByName");
                restartButtonWin.canDo = 0;
            }

            if (backButtonWin.canDo == 1)
            {
                PlayerPrefs.SetInt("LevelId", getInitialLevelId);
                StartCoroutine(LoadSceneByName("Menu", GameState.MENU));
                StopCoroutine("LoadSceneByName");
                backButtonWin.canDo = 0;
            }

            //botoes Lose
            if (restartButtonLose.canDo == 1)
            {
                PlayerPrefs.SetInt("LevelId", getInitialLevelId);
                StartCoroutine(LoadSceneByName("Game", GameState.PLAY));
                StopCoroutine("LoadSceneByName");
                restartButtonLose.canDo = 0;
            }

            if (backButtonLose.canDo == 1)
            {
                PlayerPrefs.SetInt("LevelId", getInitialLevelId);
                StartCoroutine(LoadSceneByName("Menu", GameState.MENU));
                StopCoroutine("LoadSceneByName");
                backButtonLose.canDo = 0;
            }
        }
    }

    IEnumerator LoadSceneByName(string sceneName, GameState newGameState)
    {
        yield return new WaitForSeconds(0.3f);

        Application.LoadLevel(sceneName);
        GameController.GameControllerProperties.SetCurrentGameState(newGameState);
    }

    void SupervisorBehaviour(float value)
    {
        ScoreCounter.ScoreCounterProperties.SetCaixaNegative(value);
    }

    IEnumerator HideSupervisor()
    {
        yield return new WaitForSeconds(0.3f);

        supervisorObjects.GetComponent<Animator>().Play("CloseSupervisor");
    }
    
    void CallProblems()
    {
        //Pneu Furou Fase 2
        if (PlayerPrefs.GetInt("LevelId") == 1 && levelTime > 3)
        {
            ApplyFixProblem(50, 1);
        }

        //Licenciamento Moto Fase 4
        if (PlayerPrefs.GetInt("LevelId") == 3 && PlayerPrefs.GetInt("VeicleId") == 1 && levelTime > 7)
        {
            ApplyFixProblem(100, 2);
        }

        //Licenciamento Carro Fase 6
        if (PlayerPrefs.GetInt("LevelId") == 5 && PlayerPrefs.GetInt("VeicleId") == 2 && levelTime > 20)
        {
            ApplyFixProblem(200, 3);
        }

        //Licenciamento FoodTruck Fase 10
        if (PlayerPrefs.GetInt("LevelId") == 9 && PlayerPrefs.GetInt("VeicleId") == 3 && levelTime > 15)
        {
            ApplyFixProblem(300, 4);
        }

        //Manutenção Moto Fase 3
        if (PlayerPrefs.GetInt("LevelId") == 2 && PlayerPrefs.GetInt("VeicleId") == 1 && levelTime > 10)
        {
            ApplyFixProblem(100, 5);
        }
        //Manutenção Carro Fase 5
        if (PlayerPrefs.GetInt("LevelId") == 4 && PlayerPrefs.GetInt("VeicleId") == 2 && levelTime > 10)
        {
            ApplyFixProblem(200, 6);
        }
        //Manutenção FoodTruck Fase 9
        if (PlayerPrefs.GetInt("LevelId") == 8 && PlayerPrefs.GetInt("VeicleId") == 3 && levelTime > 7)
        {
            ApplyFixProblem(300, 7);
        }
        //Problema Freezer FoodTruck Fase 10
        if (PlayerPrefs.GetInt("LevelId") == 9 && PlayerPrefs.GetInt("VeicleId") == 3 && levelTime > 15)
        {
            ApplyFixProblem(300, 8);
        }
    }
}
