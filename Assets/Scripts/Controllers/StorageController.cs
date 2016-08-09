using UnityEngine;
using System.Collections;

[System.Serializable]
public class ItensStorageClass
{
    [Header("Beverage")]
    public int coffee;
    public int soda;
    public int vitamin;
    public int chocolate;
    public int juice;

    [Header("Foods")]
    public int snack;
    public int sandwich;
    public int cake;
    public int pizza;
    public int saltPie;

    [Header("Desserts")]
    public int sweet_pie;
    public int cupCake;
    public int brownie;

    [Header("Veiculos loja")]
    public int bike;
    public int motocycle;
    public int car;
    public int foodtruck;

    [Header("Veiculos Player")]
    public GameObject bikeObject;
    public GameObject motocycleObject;
    public GameObject carObject;
    public GameObject foodtruckObject;
}

public class StorageController : MonoBehaviour
{
    public ItensStorageClass itensInstance;
    private LevelController levelController;

	void Start ()
    {
        itensInstance.bikeObject.SetActive(false);
        itensInstance.motocycleObject.SetActive(false);
        itensInstance.carObject.SetActive(false);
        itensInstance.foodtruckObject.SetActive(false);
        ScoreCounter.ScoreCounterProperties.caixa = ScoreCounter.ScoreCounterProperties.GetInitialCaixa();
        levelController = GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelController>();
    }
	
	void Update ()
    {
        //mostrar equipamento comprado
        ShowEquipmentBought();

	    if(GameController.GameControllerProperties.GetCurrentGameState() == GameState.MARKET)
        {
            //BuyMealBehaviour();
            //BuyEquipmentBehaviour();
        }
	}
    /*
    void BuyMealBehaviour()
    {
        //compra salgados
        if(buyClassInstance.buyMealButtons[0].canDo == 1)
        {
            if(ScoreCounter.ScoreCounterProperties.GetCurrentCaixa() >= 15)
            {
                itensInstance.snack += 10;
                ScoreCounter.ScoreCounterProperties.SetCaixaNegative(15);
            }

            buyClassInstance.buyMealButtons[0].canDo = 0;
        }

        //compra suco
        if (buyClassInstance.buyMealButtons[1].canDo == 1)
        {
            if (ScoreCounter.ScoreCounterProperties.GetCurrentCaixa() >= 5)
            {
                itensInstance.juice += 10;
                ScoreCounter.ScoreCounterProperties.SetCaixaNegative(5);
            }

            buyClassInstance.buyMealButtons[1].canDo = 0;
        }
        //compra torta salgada
        if (buyClassInstance.buyMealButtons[2].canDo == 1)
        {
            if (ScoreCounter.ScoreCounterProperties.GetCurrentCaixa() >= 20)
            {
                itensInstance.saltPie += 10;
                ScoreCounter.ScoreCounterProperties.SetCaixaNegative(20);
            }

            buyClassInstance.buyMealButtons[2].canDo = 0;
        }

        //compra cafe
        if (buyClassInstance.buyMealButtons[3].canDo == 1)
        {
            if (ScoreCounter.ScoreCounterProperties.GetCurrentCaixa() >= 5)
            {
                itensInstance.coffee += 10;
                ScoreCounter.ScoreCounterProperties.SetCaixaNegative(5);
            }

            buyClassInstance.buyMealButtons[3].canDo = 0;
        }

        //compra refrigerante
        if (buyClassInstance.buyMealButtons[4].canDo == 1)
        {
            if (ScoreCounter.ScoreCounterProperties.GetCurrentCaixa() >= 15)
            {
                itensInstance.soda += 10;
                ScoreCounter.ScoreCounterProperties.SetCaixaNegative(15);
            }

            buyClassInstance.buyMealButtons[4].canDo = 0;
        }

        //compra torta doce
        if (buyClassInstance.buyMealButtons[5].canDo == 1)
        {
            if (ScoreCounter.ScoreCounterProperties.GetCurrentCaixa() >= 20)
            {
                itensInstance.sweet_pie += 10;
                ScoreCounter.ScoreCounterProperties.SetCaixaNegative(20);
            }

            buyClassInstance.buyMealButtons[5].canDo = 0;
        }
        //compra vitamina
        if (buyClassInstance.buyMealButtons[6].canDo == 1)
        {
            if (ScoreCounter.ScoreCounterProperties.GetCurrentCaixa() >= 15)
            {
                itensInstance.vitamin += 10;
                ScoreCounter.ScoreCounterProperties.SetCaixaNegative(15);
            }

            buyClassInstance.buyMealButtons[6].canDo = 0;
        }

        //compra chocolate
        if (buyClassInstance.buyMealButtons[7].canDo == 1)
        {
            if (ScoreCounter.ScoreCounterProperties.GetCurrentCaixa() >= 20)
            {
                itensInstance.chocolate += 10;
                ScoreCounter.ScoreCounterProperties.SetCaixaNegative(20);
            }

            buyClassInstance.buyMealButtons[7].canDo = 0;
        }

        //compra cupcake
        if (buyClassInstance.buyMealButtons[8].canDo == 1)
        {
            if (ScoreCounter.ScoreCounterProperties.GetCurrentCaixa() >= 20)
            {
                itensInstance.cupCake += 10;
                ScoreCounter.ScoreCounterProperties.SetCaixaNegative(20);
            }

            buyClassInstance.buyMealButtons[8].canDo = 0;
        }

        //compra cake
        if (buyClassInstance.buyMealButtons[9].canDo == 1)
        {
            if (ScoreCounter.ScoreCounterProperties.GetCurrentCaixa() >= 10)
            {
                itensInstance.cake += 10;
                ScoreCounter.ScoreCounterProperties.SetCaixaNegative(10);
            }

            buyClassInstance.buyMealButtons[9].canDo = 0;
        }
        //compra pizza 
        if (buyClassInstance.buyMealButtons[10].canDo == 1)
        {
            if (ScoreCounter.ScoreCounterProperties.GetCurrentCaixa() >= 15)
            {
                itensInstance.pizza += 10;
                ScoreCounter.ScoreCounterProperties.SetCaixaNegative(15);
            }

            buyClassInstance.buyMealButtons[10].canDo = 0;
        }

        //compra brownie
        if (buyClassInstance.buyMealButtons[11].canDo == 1)
        {
            if (ScoreCounter.ScoreCounterProperties.GetCurrentCaixa() >= 20)
            {
                itensInstance.brownie += 10;
                ScoreCounter.ScoreCounterProperties.SetCaixaNegative(20);
            }

            buyClassInstance.buyMealButtons[11].canDo = 0;
        }

        //compra sanduiche
        if (buyClassInstance.buyMealButtons[12].canDo == 1)
        {
            if (ScoreCounter.ScoreCounterProperties.GetCurrentCaixa() >= 25)
            {
                itensInstance.sandwich += 10;
                ScoreCounter.ScoreCounterProperties.SetCaixaNegative(25);
            }

            buyClassInstance.buyMealButtons[12].canDo = 0;
        }
    }

    void BuyEquipmentBehaviour()
    {
        //compra bicicleta
        if (buyClassInstance.buyEquipmentButtons[0].canDo == 1)
        {
            if (ScoreCounter.ScoreCounterProperties.GetCurrentCaixa() >= 1500)
            {
                itensInstance.bike += 1;
                PlayerPrefs.SetInt("EquipmentBought", 1);
                ScoreCounter.ScoreCounterProperties.SetCaixaNegative(1500);
                levelController.equipmentId = 0;
            }

            buyClassInstance.buyEquipmentButtons[0].canDo = 0;
        }

        //compra moto
        if (buyClassInstance.buyEquipmentButtons[1].canDo == 1)
        {
            if (ScoreCounter.ScoreCounterProperties.GetCurrentCaixa() >= 3000)
            {
                itensInstance.motocycle += 1;
                PlayerPrefs.SetInt("EquipmentBought", 2);
                ScoreCounter.ScoreCounterProperties.SetCaixaNegative(3000);
                levelController.equipmentId = 1;
            }

            buyClassInstance.buyEquipmentButtons[1].canDo = 0;
        }

        //compra carro
        if (buyClassInstance.buyEquipmentButtons[2].canDo == 1)
        {
            if (ScoreCounter.ScoreCounterProperties.GetCurrentCaixa() >= 10000)
            {
                itensInstance.car += 1;
                PlayerPrefs.SetInt("EquipmentBought", 3);
                ScoreCounter.ScoreCounterProperties.SetCaixaNegative(10000);
                levelController.equipmentId = 2;
            }

            buyClassInstance.buyEquipmentButtons[2].canDo = 0;
        }

        //compra foodtruck
        if (buyClassInstance.buyEquipmentButtons[3].canDo == 1)
        {
            if (ScoreCounter.ScoreCounterProperties.GetCurrentCaixa() >= 30000)
            {
                itensInstance.foodtruck += 1;
                PlayerPrefs.SetInt("EquipmentBought", 4);
                ScoreCounter.ScoreCounterProperties.SetCaixaNegative(30000);
                levelController.equipmentId = 3;
            }

            buyClassInstance.buyEquipmentButtons[3].canDo = 0;
        }
    }
    */
    //mostra equipamento comprado
    void ShowEquipmentBought()
    {
        //bike
        if (PlayerPrefs.GetInt("VeicleId") == 0 && PlayerPrefs.GetInt("QtnBike") > 0)
        {
            itensInstance.bikeObject.SetActive(true);
            itensInstance.motocycleObject.SetActive(false);
            itensInstance.carObject.SetActive(false);
            itensInstance.foodtruckObject.SetActive(false);
        }

        //moto
        else if (PlayerPrefs.GetInt("VeicleId") == 1 && PlayerPrefs.GetInt("QtnMotocycle") > 0)
        {
            itensInstance.bikeObject.SetActive(false);
            itensInstance.motocycleObject.SetActive(true);
            itensInstance.carObject.SetActive(false);
            itensInstance.foodtruckObject.SetActive(false);
        }

        //carro
        else if (PlayerPrefs.GetInt("VeicleId") == 2 && PlayerPrefs.GetInt("QtnCar") > 0)
        {
            itensInstance.bikeObject.SetActive(false);
            itensInstance.motocycleObject.SetActive(false);
            itensInstance.carObject.SetActive(true);
            itensInstance.foodtruckObject.SetActive(false);
        }
        
        //foodtruck
        else if (PlayerPrefs.GetInt("VeicleId") == 3 && PlayerPrefs.GetInt("QtnFoodtruck") > 0)
        {
            itensInstance.bikeObject.SetActive(false);
            itensInstance.motocycleObject.SetActive(false);
            itensInstance.carObject.SetActive(false);
            itensInstance.foodtruckObject.SetActive(true);
        }

        else
        {
            Debug.Log("Entrou else");
            itensInstance.bikeObject.SetActive(false);
            itensInstance.motocycleObject.SetActive(false);
            itensInstance.carObject.SetActive(false);
            itensInstance.foodtruckObject.SetActive(false);
        }

        Debug.Log("veiculoId"+PlayerPrefs.GetInt("VeicleId")+"Qtd"+PlayerPrefs.GetInt("QtnVeicle"));
    }

    //Coxinha
    public int GetSnack()
    {
        return itensInstance.snack;
    }

    public void SetSnack(int value)
    {
        if (itensInstance.snack > 0)
        {
            itensInstance.snack -= value;
        }
    }

    //Suco
    public int GetJuice()
    {
        return itensInstance.juice;
    }

    public void SetJuice(int value)
    {
        if (itensInstance.juice > 0)
        {
            itensInstance.juice -= value;
        }
    }

    //Café
    public int GetCoffee()
    {
        return itensInstance.coffee;
    }

    public void SetCoffee(int value)
    {
        if (itensInstance.coffee > 0)
        {
            itensInstance.coffee -= value;
        }
    }

    //Refrigerante
    public int GetSoda()
    {
        return itensInstance.soda;
    }

    public void SetSoda(int value)
    {
        if (itensInstance.soda > 0)
        {
            itensInstance.soda -= value;
        }
    }

    //Vitamina
    public int GetVitamin()
    {
        return itensInstance.vitamin;
    }

    public void SetVitamin(int value)
    {
        if (itensInstance.vitamin > 0)
        {
            itensInstance.vitamin -= value;
        }
    }

    //Chocolate Quente
    public int GetChocolate()
    {
        return itensInstance.chocolate;
    }

    public void SetChocolate(int value)
    {
        if (itensInstance.chocolate > 0)
        {
            itensInstance.chocolate -= value;
        }
    }

    //Sanduiche
    public int GetSandwich()
    {
        return itensInstance.sandwich;
    }

    public void SetSandwich(int value)
    {
        if (itensInstance.sandwich > 0)
        {
            itensInstance.sandwich -= value;
        }
    }

    //Bolo
    public int GetCake()
    {
        return itensInstance.cake;
    }

    public void SetCake(int value)
    {
        if (itensInstance.cake > 0)
        {
            itensInstance.cake -= value;
        }
    }

    //Pizza
    public int GetPizza()
    {
        return itensInstance.pizza;
    }

    public void SetPizza(int value)
    {
        if (itensInstance.pizza > 0)
        {
            itensInstance.pizza -= value;
        }
    }

    //Torta Salgada
    public int GetSaltPie()
    {
        return itensInstance.saltPie;
    }

    public void SetSaltPie(int value)
    {
        if (itensInstance.saltPie > 0)
        {
            itensInstance.saltPie -= value;
        }
    }

    //Torta Doce
    public int GetSweetPie()
    {
        return itensInstance.sweet_pie;
    }

    public void SetSweetPie(int value)
    {
        if (itensInstance.sweet_pie > 0)
        {
            itensInstance.sweet_pie -= value;
        }
    }

    //Cupcake
    public int GetCupCake()
    {
        return itensInstance.cupCake;
    }

    public void SetCupCake(int value)
    {
        if (itensInstance.cupCake > 0)
        {
            itensInstance.cupCake -= value;
        }
    }

    //Brownie
    public int GetBrownie()
    {
        return itensInstance.brownie;
    }

    public void SetBrownie(int value)
    {
        if (itensInstance.brownie > 0)
        {
            itensInstance.brownie -= value;
        }
    }

    //Bike
    public int GetBike()
    {
        return itensInstance.bike;
    }

    public void SetBike(int value)
    {
        if (itensInstance.bike > 0)
        {
            itensInstance.bike -= value;
        }
    }

    //Motocycle
    public int GetMotocycle()
    {
        return itensInstance.motocycle;
    }

    public void SetMotocycle(int value)
    {
        if (itensInstance.motocycle > 0)
        {
            itensInstance.motocycle -= value;
        }
    }

    //Car
    public int GetCar()
    {
        return itensInstance.car;
    }

    public void SetCar(int value)
    {
        if (itensInstance.car > 0)
        {
            itensInstance.car -= value;
        }
    }

    //Foodtruck
    public int GetFoodtruck()
    {
        return itensInstance.foodtruck;
    }

    public void SetFoodtruck(int value)
    {
        if (itensInstance.foodtruck > 0)
        {
            itensInstance.foodtruck -= value;
        }
    }
}
