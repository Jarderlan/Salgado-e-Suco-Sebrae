using UnityEngine;
using System.Collections;

public class GameOverBalance : MonoBehaviour
{
    //Quantidade de itens vendidos
    public float[] qtnItensSold;
    //Calcula sub total de cada item
    public float[] calcSubTotal;
    [Header("Valores de venda de cada item")]
    public float[] itensPrice;
    //Calcula total de itens
    [HideInInspector]
    public float calcTotal;
    private bool canCalcSubTotal = true;
    private bool canCalcTotal = true;
    private float bonusEquipment;
    private float multiplyByQtn;
    private float bonusPosition;
    public PlayerBehaviour playerBehaviour;
    void Start () 
    {
	
	}
	
	void Update () 
    {
	    if(GameController.GameControllerProperties.GetCurrentGameState() == GameState.GAME_OVER)
        {
            CalcSubTotal();
            CalcTotal();
        }
	}

    void CalcSubTotal()
    {
        if(canCalcSubTotal)
        {
            for (int i = 0; i < qtnItensSold.Length; i++)
            {
                calcSubTotal[i] = qtnItensSold[i] * itensPrice[i];
            }
                
            canCalcSubTotal = false;
        }
    }

    void CalcTotal()
    {
        if (canCalcTotal)
        {
            for (int i = 0; i < qtnItensSold.Length; i++)
            {
                calcTotal += calcSubTotal[i];
            }

            canCalcTotal = false;
        }
    }

    void CheckVeicleId()
    {
        if (PlayerPrefs.GetInt("VeicleId") == 0 && PlayerPrefs.GetInt("QtnBike") > 0)
        {
            bonusEquipment = 1.10f;
            multiplyByQtn = PlayerPrefs.GetInt("QtnBike");
        }

        if (PlayerPrefs.GetInt("VeicleId") == 1 && PlayerPrefs.GetInt("QtnMotocycle") > 0)
        {
            bonusEquipment = 1.25f;
            multiplyByQtn = PlayerPrefs.GetInt("QtnMotocycle");
        }

        if (PlayerPrefs.GetInt("VeicleId") == 2 && PlayerPrefs.GetInt("QtnCar") > 0)
        {
            bonusEquipment = 1.50f;
            multiplyByQtn = PlayerPrefs.GetInt("QtnCar");
        }

        if (PlayerPrefs.GetInt("VeicleId") == 3 && PlayerPrefs.GetInt("QtnFoodtruck") > 0)
        {
            bonusEquipment = 1.75f;
            multiplyByQtn = PlayerPrefs.GetInt("QtnFoodtruck");
        }
    }

    void CheckLocal()
    {
        if (playerBehaviour.bonusPositionID == 0)
        {
            bonusPosition = 1;
        }
        if (playerBehaviour.bonusPositionID == 1)
        {
            bonusPosition = 1.25f;
        }
        if (playerBehaviour.bonusPositionID == 2)
        {
            bonusPosition = 1.50f;
        }
    }
}
