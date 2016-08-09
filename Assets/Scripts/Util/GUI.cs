using UnityEngine;
using System.Collections;

[System.Serializable]
public class ShowGameOverBalanceClass
{
    [Header("Campos Tabela")]
    public TextMesh[] showQtnSoldText;
    public TextMesh[] showCalcSubTotalText;
    public TextMesh showCalcTotalText;
}

[System.Serializable]
public class ShowScoresGuiClass
{
    public TextMesh showMeta;
    public TextMesh showCaixa;
    public TextMesh showScore;
    public TextMesh showBestScore;
}

[System.Serializable]
public class ShowQtnItensStorageClass
{
    public TextMesh[] showQtnItens;
}

public class GUI : MonoBehaviour
{
    public Tutorial tutorialBehaviour;
    [Header("Mostra tabela balanco game over")]
    public ShowGameOverBalanceClass showGameOverInstance;
    private GameOverBalance gameOverBalance;

    [Header("Mostra Caixa, Meta, Score e BestScore")]
    public ShowScoresGuiClass showScoresInstance;

    [Header("Mostra Quantidade itens Estoque")]
    public ShowQtnItensStorageClass showQtnStorageItensInstance;
    public StorageController storageController;
    public string textFile = "GUI";
    private string textFileContents;
    private string[] splitGUI;
    private int splitLength;
    private TextAsset txtAssets;
    private LevelController levelController;
    private int convertScore;
    private int convertCaixa;

    [Header("Mostra texto fiscal")]
    public TextMesh showSupervisorText;

    [Header("Mostra problemas de manutencao")]
    public TextMesh showFixProblemsText;

    [Header("Mostra tempo de jogo")]
    public TextMesh showMinutes;
    public TextMesh showSeconds;

    [Header("Mostra texto tutorial")]
    public TextMesh showTutorialText;

	void Start ()
    {
        DefaultTextLayer();
        gameOverBalance = GameObject.FindGameObjectWithTag("GameOverBalance").GetComponent<GameOverBalance>();
        levelController = GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelController>();
        TextAsset txtAssets = (TextAsset)Resources.Load(textFile);

        if (txtAssets != null)
        {
            textFileContents = txtAssets.text;
            splitGUI = textFileContents.Split('|');
            splitLength = splitGUI.Length;
        }
	}

    void DefaultTextLayer()
    {
        showScoresInstance.showCaixa.GetComponent<MeshRenderer>().sortingOrder = 3;
        showScoresInstance.showMeta.GetComponent<MeshRenderer>().sortingOrder = 3;
        showScoresInstance.showScore.GetComponent<MeshRenderer>().sortingOrder = 3;
        showScoresInstance.showBestScore.GetComponent<MeshRenderer>().sortingOrder = 3;
        showSupervisorText.GetComponent<MeshRenderer>().sortingOrder = 3;
        showFixProblemsText.GetComponent<MeshRenderer>().sortingOrder = 3;
        showTutorialText.GetComponent<MeshRenderer>().sortingOrder = 10;
    }

    //mostra gui problemas
    public void ShowFixProblem(int fixIndex)
    {
        if (splitLength != 0)
        {
            showFixProblemsText.text = splitGUI[fixIndex];
        }
    }
	
	void Update ()
    {
        convertScore = (int)levelController.score;
        convertCaixa = (int)ScoreCounter.ScoreCounterProperties.GetCurrentCaixa();
        //mostra caixa, meta, score e best score
        showScoresInstance.showCaixa.text = "R$ " + convertCaixa.ToString() + ",00";
        showScoresInstance.showMeta.text = ScoreCounter.ScoreCounterProperties.GetInitialMetaMensal().ToString();
        showScoresInstance.showScore.text = convertScore.ToString();
        showScoresInstance.showBestScore.text = PlayerPrefs.GetInt("HighScore").ToString();
        //tempo de jogo
        showMinutes.text = string.Format("{00:00}:", levelController.countMinutes);
        showSeconds.text = levelController.countSeconds.ToString("F0");
        
        if (GameController.GameControllerProperties.GetCurrentGameState() == GameState.PLAY
        || GameController.GameControllerProperties.GetCurrentGameState() == GameState.MARKET)
        {
            ShowIStorageItens();

            //mostra gui do arquivo externo
            if (splitLength != 0)
            {
                showSupervisorText.text = splitGUI[0];
            }
        }

        if (GameController.GameControllerProperties.GetCurrentGameState() == GameState.GAME_OVER)
        {
            ShowBalance();
        }

        ShowTutorial(tutorialBehaviour.tutorialGuiIndex);
	}

    void ShowTutorial(int tutorialGuiIndex)
    {
        showTutorialText.text = splitGUI[tutorialGuiIndex];
    }

    //mostra itens estoque
    void ShowIStorageItens()
    {
        //comida
        showQtnStorageItensInstance.showQtnItens[0].text = storageController.GetSnack().ToString();
        showQtnStorageItensInstance.showQtnItens[1].text = storageController.GetJuice().ToString();
        showQtnStorageItensInstance.showQtnItens[2].text = storageController.GetSandwich().ToString();
        showQtnStorageItensInstance.showQtnItens[3].text = storageController.GetCoffee().ToString();
        showQtnStorageItensInstance.showQtnItens[4].text = storageController.GetSweetPie().ToString();
        showQtnStorageItensInstance.showQtnItens[5].text = storageController.GetPizza().ToString();
        showQtnStorageItensInstance.showQtnItens[6].text = storageController.GetSoda().ToString();
        showQtnStorageItensInstance.showQtnItens[7].text = storageController.GetCake().ToString();
        showQtnStorageItensInstance.showQtnItens[8].text = storageController.GetVitamin().ToString();
        showQtnStorageItensInstance.showQtnItens[9].text = storageController.GetCupCake().ToString();
        showQtnStorageItensInstance.showQtnItens[10].text = storageController.GetBrownie().ToString();
        showQtnStorageItensInstance.showQtnItens[11].text = storageController.GetChocolate().ToString();
        //veiculos
        if (PlayerPrefs.GetInt("VeicleId") == 0)
        {
            showQtnStorageItensInstance.showQtnItens[12].text = PlayerPrefs.GetInt("QtnBike").ToString();
        }
        else
        {
            showQtnStorageItensInstance.showQtnItens[12].text = storageController.GetBike().ToString();
        }

        if (PlayerPrefs.GetInt("VeicleId") == 1)
        {
            showQtnStorageItensInstance.showQtnItens[13].text = PlayerPrefs.GetInt("QtnMotocycle").ToString();
        }
        else
        {
            showQtnStorageItensInstance.showQtnItens[13].text = storageController.GetMotocycle().ToString();
        }

        if (PlayerPrefs.GetInt("VeicleId") == 2)
        {
            showQtnStorageItensInstance.showQtnItens[14].text = PlayerPrefs.GetInt("QtnCar").ToString();
        }
        else
        {
            showQtnStorageItensInstance.showQtnItens[14].text = storageController.GetCar().ToString();
        }

        if (PlayerPrefs.GetInt("VeicleId") == 3)
        {
            showQtnStorageItensInstance.showQtnItens[15].text = PlayerPrefs.GetInt("QtnFoodtruck").ToString();
        }
        else
        {
            showQtnStorageItensInstance.showQtnItens[15].text = storageController.GetFoodtruck().ToString();
        }
    }

    void ShowBalance()
    {
        for (int i = 0; i < gameOverBalance.qtnItensSold.Length; i++)
        {
            showGameOverInstance.showQtnSoldText[i].text = gameOverBalance.qtnItensSold[i].ToString();
            showGameOverInstance.showCalcSubTotalText[i].text = gameOverBalance.calcSubTotal[i].ToString();
            showGameOverInstance.showCalcTotalText.text = gameOverBalance.calcTotal.ToString();
        }
    }
}
