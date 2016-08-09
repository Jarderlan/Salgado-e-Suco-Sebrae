using UnityEngine;
using System.Collections;

public class MarketOrganize : MonoBehaviour
{
    private StorageController storageController;
    [Header("Itens")]
    public TouchButton[] plusButton;
    public TouchButton[] minusButton;
    public TextMesh[] showQtnItem;
    public int[] countItem = new int[16];
    public float[] itenPrice = new float[16];
    [Header("Total Comprado")]
    public float totalBought;
    public TextMesh showTotalBought;
    public TouchButton buyButton;

	void Start ()
    {
        storageController = GameObject.FindGameObjectWithTag("StorageController").GetComponent<StorageController>();
	}
	
	void Update ()
    {
	    if(GameController.GameControllerProperties.GetCurrentGameState() == GameState.MARKET)
        {
            if (plusButton[12].canDo == 1 && PlayerPrefs.GetInt("Tutorial") == 0)
            {
                FindObjectOfType<Tutorial>().tutorialId++;
            }

            PlusVeicle();
            MinusVeicle();
            PlusItem();
            MinusItem();
            ShowItem();

            showTotalBought.text = "R$ "+totalBought.ToString();

            if(totalBought > ScoreCounter.ScoreCounterProperties.GetCurrentCaixa())
            {
                showTotalBought.color = Color.red;
            }

            else
            {
                showTotalBought.color = Color.white;
            }

            //botao compra
            if (buyButton.canDo == 1 && ScoreCounter.ScoreCounterProperties.GetCurrentCaixa() >= totalBought)
            {
                if (PlayerPrefs.GetInt("Tutorial") == 0)
                {
                    FindObjectOfType<Tutorial>().tutorialId++;
                }

                ScoreCounter.ScoreCounterProperties.SetCaixaNegative(totalBought);
                SetItens();
                totalBought = 0;

                for (int i = 0; i < countItem.Length; i++)
                {
                    countItem[i] = 0;
                }

                SoundController.PlaySound(SoundState.BUTTON_CLIC);
                buyButton.canDo = 0;
            }

        }
	}

    void SetItens()
    {
        //seta itens
        if (countItem[0] > 0)
        {
            storageController.itensInstance.snack += countItem[0];
        }

        if (countItem[1] > 0)
        {
            storageController.itensInstance.juice += countItem[1];
        }

        if (countItem[2] > 0)
        {
            storageController.itensInstance.sandwich += countItem[2];
        }

        if (countItem[3] > 0)
        {
            storageController.itensInstance.coffee += countItem[3];
        }
        
        if (countItem[4] > 0)
        {
            storageController.itensInstance.sweet_pie += countItem[4];
        }

        if (countItem[5] > 0)
        {
            storageController.itensInstance.pizza += countItem[5];
        }

        if (countItem[6] > 0)
        {
            storageController.itensInstance.soda += countItem[6];
        }

        if (countItem[7] > 0)
        {
            storageController.itensInstance.cake += countItem[7];
        }

        if (countItem[8] > 0)
        {
            storageController.itensInstance.vitamin += countItem[8];
        }

        if (countItem[9] > 0)
        {
            storageController.itensInstance.cupCake += countItem[9];
        }

        if (countItem[10] > 0)
        {
            storageController.itensInstance.brownie += countItem[10];
        }

        if (countItem[11] > 0)
        {
            storageController.itensInstance.chocolate += countItem[11];
        }

        //seta veiculos
        if (countItem[12] > 0)
        {
            storageController.itensInstance.bike += countItem[12];
        }

        if (countItem[13] > 0)
        {
            storageController.itensInstance.motocycle += countItem[13];
        }

        if (countItem[14] > 0)
        {
            storageController.itensInstance.car += countItem[14];
        }

        if (countItem[15] > 0)
        {
            storageController.itensInstance.foodtruck += countItem[15];
        }
    }

    void PlusItem()
    {
        for (int i = 0; i < plusButton.Length - 4; i++)
        {
            if (plusButton[i].canDo == 1)
            {
                countItem[i] += 10;
                totalBought += 10 * itenPrice[i];
                SoundController.PlaySound(SoundState.TIC);
                plusButton[i].canDo = 0;
            }
        }
    }

    void MinusItem()
    {
        for (int i = 0; i < minusButton.Length - 4; i++)
        {
            if (minusButton[i].canDo == 1)
            {
                if (countItem[i] > 0)
                {
                    countItem[i] -= 10;
                    totalBought -= 10 * itenPrice[i];
                    SoundController.PlaySound(SoundState.TIC);
                    minusButton[i].canDo = 0;
                }
            }
        }
    }

    void PlusVeicle()
    {
        //bike
        if(plusButton[12].canDo == 1)
        {
            PlayerPrefs.SetInt("VeicleId", 0);
            PlayerPrefs.SetInt("QtnBike", PlayerPrefs.GetInt("QtnBike") + 1);
        }

        if (plusButton[13].canDo == 1)
        {
            PlayerPrefs.SetInt("VeicleId", 1);
            PlayerPrefs.SetInt("QtnMotocycle", PlayerPrefs.GetInt("QtnMotocycle") + 1);
        }

        if (plusButton[14].canDo == 1)
        {
            PlayerPrefs.SetInt("VeicleId", 2);
            PlayerPrefs.SetInt("QtnCar", PlayerPrefs.GetInt("QtnCar") + 1);
        }

        if (plusButton[15].canDo == 1)
        {
            PlayerPrefs.SetInt("VeicleId", 3);
            PlayerPrefs.SetInt("QtnFoodtruck", PlayerPrefs.GetInt("QtnFoodtruck") + 1);
        }        

        for (int i = 12; i < plusButton.Length; i++)
        {
            if (plusButton[i].canDo == 1)
            {
                countItem[i] += 1;
                totalBought += 1 * itenPrice[i];
                SoundController.PlaySound(SoundState.TIC);
                plusButton[i].canDo = 0;
            }
        }
    }

    void MinusVeicle()
    {
        //bike
        if (minusButton[12].canDo == 1 && PlayerPrefs.GetInt("QtnBike") > 0)
        {
            PlayerPrefs.SetInt("VeicleId", 0);
            PlayerPrefs.SetInt("QtnBike", PlayerPrefs.GetInt("QtnBike") - 1);
        }

        if (minusButton[13].canDo == 1 && PlayerPrefs.GetInt("QtnMotocycle") > 0)
        {
            PlayerPrefs.SetInt("VeicleId", 1);
            PlayerPrefs.SetInt("QtnMotocycle", PlayerPrefs.GetInt("QtnMotocycle") - 1);
        }

        if (minusButton[14].canDo == 1 && PlayerPrefs.GetInt("QtnCar") > 0)
        {
            PlayerPrefs.SetInt("VeicleId", 2);
            PlayerPrefs.SetInt("QtnCar", PlayerPrefs.GetInt("QtnCar") - 1);
        }

        if (minusButton[15].canDo == 1 && PlayerPrefs.GetInt("QtnFoodtruck") > 0)
        {
            PlayerPrefs.SetInt("VeicleId", 3);
            PlayerPrefs.SetInt("QtnFoodtruck", PlayerPrefs.GetInt("QtnFoodtruck") - 1);
        }

        for (int i = 12; i < minusButton.Length; i++)
        {
            if (minusButton[i].canDo == 1)
            {
                if (countItem[i] > 0)
                {
                    countItem[i] -= 1;
                    totalBought -= 1 * itenPrice[i];
                    SoundController.PlaySound(SoundState.TIC);
                    minusButton[i].canDo = 0;
                }
            }
        }
    }

    void ShowItem()
    {
        for (int i = 0; i < showQtnItem.Length; i++)
        {
            showQtnItem[i].text = countItem[i].ToString();
        }
    }
}
