using UnityEngine;
using System.Collections;

public class NpcBehaviour : MonoBehaviour
{
    [Header("Roupas diferentes ")]
    public Texture[] npcTextures;
    private int sortClothes;
    private Renderer renderer;

    [Header("Range e Movimentação")]
    public float speed;
    private Transform playerTarget;
    public float distanceToFollow;
    //
    private StorageController storageController;
    private LevelController levelController;
    private GameOverBalance gameOverBalance;
    private bool canBuy = true;
    private int sortMealCombo;
    private Transform defaultTarget;
    private bool canPlayerTarget = true;
    public float multiplyScore;
    public float multiplyByQtn;
    public float bonusEquipment;
    public float bonusPosition;
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    [Header("Moeda para compra")]
    public Coin coin;
    private bool buyWithCoin;
    private int foodId;
    private int drinkId;
    private int dessertId;

    void Awake()
    {
        if (coin != null)
        {
            coin.gameObject.SetActive(false);
        }

        renderer = GetComponentInChildren<Renderer>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        gameOverBalance = GameObject.FindGameObjectWithTag("GameOverBalance").GetComponent<GameOverBalance>();
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        defaultTarget = GameObject.FindGameObjectWithTag("DefaultTarget").transform;
        storageController = GameObject.FindGameObjectWithTag("StorageController").GetComponent<StorageController>();
        levelController = GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelController>();
        sortClothes = Random.Range(0, npcTextures.Length);
        sortMealCombo = Random.Range(0, 6);

        if (renderer != null)
        {
            renderer.material.mainTexture = npcTextures[sortClothes];
        }
    }

    void Update()
    {
        if (GameController.GameControllerProperties.GetCurrentGameState() == GameState.PLAY)
        {
            navMeshAgent.enabled = true;
            animator.enabled = true;

            //seguir player
            if (canPlayerTarget)
            {
                if (navMeshAgent.enabled)
                {
                    navMeshAgent.destination = playerTarget.position;
                }
            }

            //comprar e sair
            if (Vector3.Distance(transform.position, playerTarget.position) <= distanceToFollow)
            {
                if (animator.enabled)
                {
                    animator.SetBool("CanWalk", false);
                }

                Buy();
                canPlayerTarget = false;
            }

            //andar
            else
            {
                if (animator.enabled)
                {
                    animator.SetBool("CanWalk", true);
                }
            }

            //compra c moeda
            BuyWithCoin(drinkId, foodId, dessertId);
        }

        //parar
        else
        {
            navMeshAgent.enabled = false;
            animator.enabled = false;
        }
    }

    void BuyWithCoin(int drinkId, int foodId, int dessertId)
    {
        if (buyWithCoin)
        {
            if (drinkId == 0)
            {
                if (coin != null && coin.canTakeMoney == 1)
                {
                    ScoreCounter.ScoreCounterProperties.SetCaixaPositive(multiplyByQtn*(1 * bonusEquipment * bonusPosition));
                    levelController.score += multiplyByQtn*(1 * multiplyScore);
                    gameOverBalance.qtnItensSold[1] += 1;
                    buyWithCoin = false;
                }
            }

            if (drinkId == 1)
            {
                if (coin != null && coin.canTakeMoney == 1)
                {
                    ScoreCounter.ScoreCounterProperties.SetCaixaPositive(multiplyByQtn * (0 * bonusEquipment * bonusPosition));
                    levelController.score += multiplyByQtn * (100 * multiplyScore);
                    gameOverBalance.qtnItensSold[3] += 1;
                    buyWithCoin = false;
                }
            }

            if (drinkId == 2)
            {
                if (coin != null && coin.canTakeMoney == 1)
                {
                    ScoreCounter.ScoreCounterProperties.SetCaixaPositive(multiplyByQtn * (2.5f * bonusEquipment * bonusPosition));
                    levelController.score += multiplyByQtn * (2.5f * multiplyScore);
                    gameOverBalance.qtnItensSold[6] += 1;
                    buyWithCoin = false;
                }
            }

            if (drinkId == 3)
            {
                if (coin != null && coin.canTakeMoney == 1)
                {
                    ScoreCounter.ScoreCounterProperties.SetCaixaPositive(multiplyByQtn * (4 * bonusEquipment * bonusPosition));
                    levelController.score += multiplyByQtn * (4 * multiplyScore);
                    gameOverBalance.qtnItensSold[8] += 1;
                    buyWithCoin = false;
                }
            }

            if (drinkId == 4)
            {
                if (coin != null && coin.canTakeMoney == 1)
                {
                    ScoreCounter.ScoreCounterProperties.SetCaixaPositive(multiplyByQtn * (4 * bonusEquipment * bonusPosition));
                    levelController.score += multiplyByQtn * (4 * multiplyScore);
                    gameOverBalance.qtnItensSold[12] += 1;
                    buyWithCoin = false;
                }
            }

            //O 5 Não Existe.

            if(foodId == 6 || foodId ==7)
            {
                if(coin != null && coin.canTakeMoney == 1)
                {
                    ScoreCounter.ScoreCounterProperties.SetCaixaPositive(multiplyByQtn * (2.5f * bonusEquipment * bonusPosition));
                    levelController.score += multiplyByQtn * (2.5f * multiplyScore);
                    gameOverBalance.qtnItensSold[0] += 1;
                    buyWithCoin = false;
                }
            }

            if (foodId == 8)
            {
                if (coin != null && coin.canTakeMoney == 1)
                {
                    ScoreCounter.ScoreCounterProperties.SetCaixaPositive(multiplyByQtn * (4 * bonusEquipment * bonusPosition));
                    levelController.score += multiplyByQtn * (4 * multiplyScore);
                    gameOverBalance.qtnItensSold[2] += 1;
                    buyWithCoin = false;
                }
            }

            if (foodId == 9)
            {
                if (coin != null && coin.canTakeMoney == 1)
                {
                    ScoreCounter.ScoreCounterProperties.SetCaixaPositive(multiplyByQtn * (2 * bonusEquipment * bonusPosition));
                    levelController.score += multiplyByQtn * (2 * multiplyScore);
                    gameOverBalance.qtnItensSold[4] += 1;
                    buyWithCoin = false;
                }
            }

            if (foodId == 10)
            {
                if (coin != null && coin.canTakeMoney == 1)
                {
                    ScoreCounter.ScoreCounterProperties.SetCaixaPositive(multiplyByQtn * (2.5f * bonusEquipment * bonusPosition));
                    levelController.score += multiplyByQtn * (2.5f * multiplyScore);
                    gameOverBalance.qtnItensSold[5] += 1;
                    buyWithCoin = false;
                }
            }

            if (foodId == 11)
            {
                if (coin != null && coin.canTakeMoney == 1)
                {
                    ScoreCounter.ScoreCounterProperties.SetCaixaPositive(multiplyByQtn * (3.5f * bonusEquipment * bonusPosition));
                    levelController.score += multiplyByQtn * (3.5f * multiplyScore);
                    gameOverBalance.qtnItensSold[7] += 1;
                    buyWithCoin = false;
                }
            }

            if (dessertId == 12)
            {
                if (coin != null && coin.canTakeMoney == 1)
                {
                    ScoreCounter.ScoreCounterProperties.SetCaixaPositive(multiplyByQtn * (3.5f * bonusEquipment * bonusPosition));
                    levelController.score += multiplyByQtn * (3.5f * multiplyScore);
                    gameOverBalance.qtnItensSold[9] += 1;
                    buyWithCoin = false;
                }
            }

            if (dessertId == 13)
            {
                if (coin != null && coin.canTakeMoney == 1)
                {
                    ScoreCounter.ScoreCounterProperties.SetCaixaPositive(multiplyByQtn * (4 * bonusEquipment * bonusPosition));
                    levelController.score += multiplyByQtn * (4 * multiplyScore);
                    gameOverBalance.qtnItensSold[10] += 1;
                    buyWithCoin = false;
                }
            }

            if (dessertId == 14)
            {
                if (coin != null && coin.canTakeMoney == 1)
                {
                    ScoreCounter.ScoreCounterProperties.SetCaixaPositive(multiplyByQtn * (4 * bonusEquipment * bonusPosition));
                    levelController.score += multiplyByQtn * (4 * multiplyScore);
                    gameOverBalance.qtnItensSold[11] += 1;
                    buyWithCoin = false;
                }
            }
        }
    }

    void Buy()
    {
        if (canBuy)
        {
            if (PlayerPrefs.GetInt("LevelId") == 0)
            {
                LevelOne();
            }

            if (PlayerPrefs.GetInt("LevelId") == 1)
            {
                LevelTwo();
            }

            if (PlayerPrefs.GetInt("LevelId") == 2)
            {
                LevelThree();
            }

            if (PlayerPrefs.GetInt("LevelId") == 3)
            {
                LevelFour();
            }

            if (PlayerPrefs.GetInt("LevelId") == 4)
            {
                LevelFive();
            }

            if (PlayerPrefs.GetInt("LevelId") == 5)
            {
                LevelSix();
            }

            if (PlayerPrefs.GetInt("LevelId") == 6)
            {
                LevelSeven();
            }

            if (PlayerPrefs.GetInt("LevelId") == 7)
            {
                LevelEight();
            }

            if (PlayerPrefs.GetInt("LevelId") == 8)
            {
                LevelNine();
            }

            if (PlayerPrefs.GetInt("LevelId") == 9)
            {
                LevelTen();
            }
        }
    }

    void LevelOne()
    {
        if (sortMealCombo == 0)
        {
            CheckLocal();
            CheckVeicleId();
            SortDrinkAndBuy(0, 0);
            canBuy = false;
        }

        if (sortMealCombo == 1)
        {
            CheckLocal();
            CheckVeicleId();
            SortDrinkAndBuy(0, 1);
            canBuy = false;
        }

        if (sortMealCombo == 2)
        {
            CheckLocal();
            CheckVeicleId();
            SortFoodAndBuy(6, 7);
            canBuy = false;
        }

        if (sortMealCombo == 3)
        {
            CheckLocal();
            CheckVeicleId();
            SortFoodAndBuy(6, 8);
            canBuy = false;
        }

        if (sortMealCombo == 4)
        {
            CheckLocal();
            CheckVeicleId();
            SortDrinkAndBuy(0, 0);
            SortFoodAndBuy(6, 7);
            canBuy = false;
        }

        if (sortMealCombo == 5)
        {
            CheckLocal();
            CheckVeicleId();
            SortDrinkAndBuy(0, 0);
            SortFoodAndBuy(6, 7);
            canBuy = false;
        }

        if (sortMealCombo == 6)
        {
            CheckLocal();
            CheckVeicleId();
            SortDrinkAndBuy(0, 1);
            SortFoodAndBuy(6, 8);
            canBuy = false;
        }
    }

    void LevelTwo()
    {
        if (sortMealCombo == 0)
        {
            SortDrinkAndBuy(0, 1);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 1)
        {
            SortDrinkAndBuy(0, 1);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 2)
        {
            SortFoodAndBuy(6, 8);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 3)
        {
            SortFoodAndBuy(6, 8);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 4)
        {
            SortDrinkAndBuy(0, 1);
            SortFoodAndBuy(6, 8);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 5)
        {
            SortDrinkAndBuy(0, 1);
            SortFoodAndBuy(6, 8);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 6)
        {
            SortDrinkAndBuy(0, 1);
            SortFoodAndBuy(6, 8);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }
    }

    void LevelThree()
    {
        if (sortMealCombo == 0)
        {
            SortDrinkAndBuy(0, 1);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 1)
        {
            SortDrinkAndBuy(0, 1);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 2)
        {
            SortFoodAndBuy(6, 8);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 3)
        {
            SortFoodAndBuy(6, 8);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 4)
        {
            SortDrinkAndBuy(0, 1);
            SortFoodAndBuy(6, 8);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 5)
        {
            SortDrinkAndBuy(0, 1);
            SortFoodAndBuy(6, 8);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 6)
        {
            SortDrinkAndBuy(0, 1);
            SortFoodAndBuy(6, 8);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }
    }

    void LevelFour()
    {
        if (sortMealCombo == 0)
        {
            SortDrinkAndBuy(0, 3);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 1)
        {
            SortDrinkAndBuy(0, 3);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 2)
        {
            SortFoodAndBuy(6, 10);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 3)
        {
            SortFoodAndBuy(6, 10);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 4)
        {
            SortDrinkAndBuy(0, 3);
            SortFoodAndBuy(6, 10);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 5)
        {
            SortDrinkAndBuy(0, 3);
            SortFoodAndBuy(6, 10);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 6)
        {
            SortDrinkAndBuy(0, 3);
            SortFoodAndBuy(6, 10);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }
    }

    void LevelFive()
    {
        if (sortMealCombo == 0)
        {
            SortDrinkAndBuy(0, 3);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 1)
        {
            SortDrinkAndBuy(0, 3);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 2)
        {
            SortFoodAndBuy(6, 10);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 3)
        {
            SortFoodAndBuy(6, 10);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 4)
        {
            SortDrinkAndBuy(0, 3);
            SortFoodAndBuy(6, 10);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 5)
        {
            SortDrinkAndBuy(0, 3);
            SortFoodAndBuy(6, 10);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 6)
        {
            SortDrinkAndBuy(0, 3);
            SortFoodAndBuy(6, 10);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }
    }

    void LevelSix()
    {
        if (sortMealCombo == 0)
        {
            SortDrinkAndBuy(0, 3);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 1)
        {
            SortDrinkAndBuy(0, 3);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 2)
        {
            SortFoodAndBuy(6, 10);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 3)
        {
            SortFoodAndBuy(6, 10);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 4)
        {
            SortDrinkAndBuy(0, 3);
            SortFoodAndBuy(6, 10);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 5)
        {
            SortDrinkAndBuy(0, 3);
            SortFoodAndBuy(6, 10);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 6)
        {
            SortDrinkAndBuy(0, 3);
            SortFoodAndBuy(6, 10);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }
    }

    void LevelSeven()
    {
        if (sortMealCombo == 0)
        {
            SortDrinkAndBuy(0, 4);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 1)
        {
            SortFoodAndBuy(6, 11);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 2)
        {
            SortDessertAndBuy(12, 14);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 3)
        {
            SortDrinkAndBuy(0, 4);
            SortFoodAndBuy(6, 11);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 4)
        {
            SortDrinkAndBuy(0, 4);
            SortFoodAndBuy(6, 11);
            SortDessertAndBuy(12, 14);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 5)
        {
            SortDrinkAndBuy(0, 4);
            SortDessertAndBuy(12, 14);
            CheckLocal();
            canBuy = false;
        }

        if (sortMealCombo == 6)
        {
            SortFoodAndBuy(6, 11);
            SortDessertAndBuy(12, 14);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }
    }

    void LevelEight()
    {
        if (sortMealCombo == 0)
        {
            SortDrinkAndBuy(0, 4);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 1)
        {
            SortFoodAndBuy(6, 11);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 2)
        {
            SortDessertAndBuy(12, 14);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 3)
        {
            SortDrinkAndBuy(0, 4);
            SortFoodAndBuy(6, 11);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 4)
        {
            SortDrinkAndBuy(0, 4);
            SortFoodAndBuy(6, 11);
            SortDessertAndBuy(12, 14);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 5)
        {
            SortDrinkAndBuy(0, 4);
            SortDessertAndBuy(12, 14);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 6)
        {
            SortFoodAndBuy(6, 11);
            SortDessertAndBuy(12, 14);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }
    }

    void LevelNine()
    {
        if (sortMealCombo == 0)
        {
            SortDrinkAndBuy(0, 4);
            canBuy = false;
        }

        if (sortMealCombo == 1)
        {
            SortFoodAndBuy(6, 11);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 2)
        {
            SortDessertAndBuy(12, 14);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 3)
        {
            SortDrinkAndBuy(0, 4);
            SortFoodAndBuy(6, 11);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 4)
        {
            SortDrinkAndBuy(0, 4);
            SortFoodAndBuy(6, 11);
            SortDessertAndBuy(12, 14);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 5)
        {
            SortDrinkAndBuy(0, 4);
            SortDessertAndBuy(12, 14);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 6)
        {
            SortFoodAndBuy(6, 11);
            SortDessertAndBuy(12, 14);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }
    }

    void LevelTen()
    {
        if (sortMealCombo == 0)
        {
            SortDrinkAndBuy(0, 4);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 1)
        {
            SortFoodAndBuy(6, 11);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 2)
        {
            SortDessertAndBuy(12, 14);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 3)
        {
            SortDrinkAndBuy(0, 4);
            SortFoodAndBuy(6, 11);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 4)
        {
            SortDrinkAndBuy(0, 4);
            SortFoodAndBuy(6, 11);
            SortDessertAndBuy(12, 14);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 5)
        {
            SortDrinkAndBuy(0, 4);
            SortDessertAndBuy(12, 14);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }

        if (sortMealCombo == 6)
        {
            SortFoodAndBuy(6, 11);
            SortDessertAndBuy(12, 14);
            CheckLocal();
            CheckVeicleId();
            canBuy = false;
        }
    }

    void DestroyAfterBuy()
    {
        Destroy(gameObject);
    }

    void GoOut()
    {
        if (navMeshAgent.enabled)
        {
            navMeshAgent.destination = defaultTarget.position;
        }

        Invoke("DestroyAfterBuy", 10f);
    }

    //Sorteia qual bebida NPC vai comprar
    void SortDrinkAndBuy(int drinkMin, int drinkMax)
    {
        //Suco 0
        //Café 1
        //Refrigerante 2
        //Vitamina 3
        //Chocolate Quente 4
        int sortBuyDrink = Random.Range(drinkMin, drinkMax);
        drinkId = sortBuyDrink;

        if (sortBuyDrink == 0)
        {
            if (storageController.GetJuice() > 0)
            {
                storageController.SetJuice(1);

                if (coin != null)
                {
                    coin.gameObject.SetActive(true);
                }

                buyWithCoin = true;
                Invoke("GoOut", 2f);
            }

            else
            {
                Invoke("GoOut", 2f);
            }
        }

        if (sortBuyDrink == 1)
        {
            if (storageController.GetCoffee() > 0)
            {
                storageController.SetCoffee(1);

                if (coin != null)
                {
                    coin.gameObject.SetActive(true);
                }

                buyWithCoin = true;
                Invoke("GoOut", 2f);
            }

            else
            {
                Invoke("GoOut", 2f);
            }
        }

        if (sortBuyDrink == 2)
        {
            if (storageController.GetSoda() > 0)
            {
                storageController.SetSoda(1);

                if (coin != null)
                {
                    coin.gameObject.SetActive(true);
                }

                buyWithCoin = true;
                Invoke("GoOut", 2f);
            }

            else
            {
                Invoke("GoOut", 2f);
            }
        }

        if (sortBuyDrink == 3)
        {
            if (storageController.GetVitamin() > 0)
            {
                storageController.SetVitamin(1);

                if (coin != null)
                {
                    coin.gameObject.SetActive(true);
                }

                buyWithCoin = true;
                Invoke("GoOut", 2f);
            }

            else
            {
                Invoke("GoOut", 2f);
            }
        }

        if (sortBuyDrink == 4)
        {
            if (storageController.GetChocolate() > 0)
            {
                storageController.SetChocolate(1);

                if (coin != null)
                {
                    coin.gameObject.SetActive(true);
                }

                buyWithCoin = true;
                Invoke("GoOut", 2f);
            }

            else
            {
                Invoke("GoOut", 2f);
            }
        }
    }

    //Sorteia qual comida NPC vai comprar
    void SortFoodAndBuy(int foodMin, int foodMax)
    {
        //Coxinha 6
        //Salgado 7
        //Sanduiche 8
        //Bolo 9
        //Pizza 10
        //Torta Salgada 11
        int sortBuyFood = Random.Range(foodMin, foodMax);
        foodId = sortBuyFood;

        if (sortBuyFood == 6)
        {
            if (storageController.GetSnack() > 0)
            {
                storageController.SetSnack(1);

                if (coin != null)
                {
                    coin.gameObject.SetActive(true);
                }

                buyWithCoin = true;
                Invoke("GoOut", 2f);
            }

            else
            {
                Invoke("GoOut", 2f);
            }
        }

        //Precisa ver
        if (sortBuyFood == 7)
        {
            if (storageController.GetSweetPie() > 0)
            {
                storageController.SetSweetPie(1);
                gameOverBalance.qtnItensSold[9] += 1;

                if (coin != null)
                {
                    coin.gameObject.SetActive(true);
                }

                buyWithCoin = true;
                Invoke("GoOut", 2f);
            }

            else
            {
                Invoke("GoOut", 2f);
            }
        }

        if (sortBuyFood == 8)
        {
            if (storageController.GetSandwich() > 0)
            {
                storageController.SetSandwich(1);

                if (coin != null)
                {
                    coin.gameObject.SetActive(true);
                }

                buyWithCoin = true;
                Invoke("GoOut", 2f);
            }

            else
            {
                Invoke("GoOut", 2f);
            }
        }

        if (sortBuyFood == 9)
        {
            if (storageController.GetCake() > 0)
            {
                storageController.SetCake(1);

                if (coin != null)
                {
                    coin.gameObject.SetActive(true);
                }

                buyWithCoin = true;
                Invoke("GoOut", 2f);
            }

            else
            {
                Invoke("GoOut", 2f);
            }
        }

        if (sortBuyFood == 10)
        {
            if (storageController.GetPizza() > 0)
            {
                storageController.SetPizza(1);

                if (coin != null)
                {
                    coin.gameObject.SetActive(true);
                }

                buyWithCoin = true;
                Invoke("GoOut", 2f);
            }

            else
            {
                Invoke("GoOut", 2f);
            }
        }

        if (sortBuyFood == 11)
        {
            if (storageController.GetSaltPie() > 0)
            {
                storageController.SetSaltPie(1);

                if (coin != null)
                {
                    coin.gameObject.SetActive(true);
                }

                buyWithCoin = true;
                Invoke("GoOut", 2f);
            }

            else
            {
                Invoke("GoOut", 2f);
            }
        }
    }

    //Sorteia qual sobremesa NPC vai comprar
    void SortDessertAndBuy(int dMin, int dMax)
    {
        int sortBuyDessert = Random.Range(dMin, dMax);
        dessertId = sortBuyDessert;

        //Torta Doce 12
        //Cup Cake 13
        //Brownie 14
        if (sortBuyDessert == 12)
        {
            if (storageController.GetSweetPie() > 0)
            {
                storageController.SetSweetPie(1);

                if (coin != null)
                {
                    coin.gameObject.SetActive(true);
                }

                buyWithCoin = true;
                Invoke("GoOut", 2f);
            }

            else
            {
                Invoke("GoOut", 2f);
            }
        }

        if (sortBuyDessert == 13)
        {
            if (storageController.GetCupCake() > 0)
            {
                storageController.SetCupCake(1);

                if (coin != null)
                {
                    coin.gameObject.SetActive(true);
                }

                buyWithCoin = true;
                Invoke("GoOut", 2f);
            }

            else
            {
                Invoke("GoOut", 2f);
            }
        }

        if (sortBuyDessert == 14)
        {
            if (storageController.GetBrownie() > 0)
            {
                storageController.SetBrownie(1);

                if (coin != null)
                {
                    coin.gameObject.SetActive(true);
                }

                buyWithCoin = true;
                Invoke("GoOut", 2f);
            }

            else
            {
                Invoke("GoOut", 2f);
            }
        }
    }

    //Bonus de compra e pontos variam de acordo com o veiculo e se esse veiculo existe
    void CheckVeicleId()
    {
        if (PlayerPrefs.GetInt("VeicleId") == 0 && PlayerPrefs.GetInt("QtnBike") > 0)
        {
            multiplyScore = 100;
            bonusEquipment = 1.10f;
            multiplyByQtn = PlayerPrefs.GetInt("QtnBike");
        }

        if (PlayerPrefs.GetInt("VeicleId") == 1 && PlayerPrefs.GetInt("QtnMotocycle") > 0)
        {
            multiplyScore = 250;
            bonusEquipment = 1.25f;
            multiplyByQtn = PlayerPrefs.GetInt("QtnMotocycle");
        }

        if (PlayerPrefs.GetInt("VeicleId") == 2 && PlayerPrefs.GetInt("QtnCar") > 0)
        {
            multiplyScore = 500;
            bonusEquipment = 1.50f;
            multiplyByQtn = PlayerPrefs.GetInt("QtnCar");
        }

        if (PlayerPrefs.GetInt("VeicleId") == 3 && PlayerPrefs.GetInt("QtnFoodtruck") > 0)
        {
            multiplyScore = 1000;
            bonusEquipment = 1.75f;
            multiplyByQtn = PlayerPrefs.GetInt("QtnFoodtruck");
        }
    }

    void CheckLocal()
    {        
        if(playerTarget.GetComponent<PlayerBehaviour>().bonusPositionID == 0)
        {
            bonusPosition = 1;
        }
        if (playerTarget.GetComponent<PlayerBehaviour>().bonusPositionID == 1)
        {
            bonusPosition = 1.25f;
        }
        if (playerTarget.GetComponent<PlayerBehaviour>().bonusPositionID == 2)
        {
            bonusPosition = 1.50f;
        }
    }
}
