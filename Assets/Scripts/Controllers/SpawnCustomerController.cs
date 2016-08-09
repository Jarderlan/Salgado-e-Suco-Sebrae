using UnityEngine;
using System.Collections;

[System.Serializable]
public class CustomersClass
{
    public GameObject[] customersPrefab;
    public float timeToInstantiate;
    [HideInInspector]
    public float currentTime;
}

public class SpawnCustomerController : MonoBehaviour 
{
    [Header("Clientes")]
    public CustomersClass customersInstance;
    private Transform playerBehaviour;
    //public int minCustomerRange;
    //public int maxCustomerRange;
    private int qtnCustomers;

    //
    private LevelController levelController;

	void Start () 
    {
        //MinAndMaxCustomers();
        playerBehaviour = GameObject.FindGameObjectWithTag("Player").transform;
        levelController = GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelController>();
    }

    public void MinAndMaxCustomers(int minCustomerRange, int maxCustomerRange)
    {
        if (PlayerPrefs.GetInt("LevelId") == 0)
        {
            qtnCustomers = Random.Range(minCustomerRange, maxCustomerRange);   
        }

        if (PlayerPrefs.GetInt("LevelId") == 1)
        {
            qtnCustomers = Random.Range(minCustomerRange, maxCustomerRange);
        }

        if (PlayerPrefs.GetInt("LevelId") == 2)
        {
            qtnCustomers = Random.Range(minCustomerRange, maxCustomerRange);
        }

        if (PlayerPrefs.GetInt("LevelId") == 3)
        {
            qtnCustomers = Random.Range(minCustomerRange, maxCustomerRange);
        }

        if (PlayerPrefs.GetInt("LevelId") == 4)
        {
            qtnCustomers = Random.Range(minCustomerRange, maxCustomerRange);
        }

        if (PlayerPrefs.GetInt("LevelId") == 5)
        {
            qtnCustomers = Random.Range(minCustomerRange, maxCustomerRange);
        }

        if (PlayerPrefs.GetInt("LevelId") == 6)
        {
            qtnCustomers = Random.Range(minCustomerRange, maxCustomerRange);
        }

        if (PlayerPrefs.GetInt("LevelId") == 7)
        {
            qtnCustomers = Random.Range(minCustomerRange, maxCustomerRange);
        }

        if (PlayerPrefs.GetInt("LevelId") == 8)
        {
            qtnCustomers = Random.Range(minCustomerRange, maxCustomerRange);
        }

        if (PlayerPrefs.GetInt("LevelId") == 9)
        {
            qtnCustomers = Random.Range(minCustomerRange, maxCustomerRange);
        }
    }

	void Update () 
    {
        //CheckEquipmentId();

        if (GameController.GameControllerProperties.GetCurrentGameState() == GameState.PLAY)
        {
            if (qtnCustomers > 0)
            {
                customersInstance.currentTime += Time.deltaTime;

                if (customersInstance.currentTime > customersInstance.timeToInstantiate)
                {
                    if (customersInstance.customersPrefab != null && playerBehaviour != null)
                    {
                        int sortCustomer = Random.Range(0, customersInstance.customersPrefab.Length);
                        //customersInstance.adJust = Random.Range(-1, 1);
                        int sortX = Random.Range(-1, 1);
                        int sortZ = Random.Range(-1, 1);
                        InstantiateCustomer(customersInstance.customersPrefab[sortCustomer], new Vector3(playerBehaviour.position.x + sortX, playerBehaviour.position.y, playerBehaviour.position.z + sortZ));
                        CheckVeicleId();
                    }

                    qtnCustomers--;
                    customersInstance.currentTime = 0;
                }
            }
        }
	}

    void InstantiateCustomer(GameObject customerPrefab, Vector3 customerPosition)
    {
        Instantiate(customerPrefab, customerPosition, customerPrefab.transform.rotation);
    }

    //tempo de spawn varia de acordo com o item
    void CheckVeicleId()
    {
        if (PlayerPrefs.GetInt("VeicleId") == 0 && PlayerPrefs.GetInt("QtnBike") > 0)
        {
            customersInstance.timeToInstantiate = 10;
        }

        if (PlayerPrefs.GetInt("VeicleId") == 1 && PlayerPrefs.GetInt("QtnMotocycle") > 0)
        {
            customersInstance.timeToInstantiate = 8;
        }

        if (PlayerPrefs.GetInt("VeicleId") == 2 && PlayerPrefs.GetInt("QtnCar") > 0)
        {
            customersInstance.timeToInstantiate = 6;
        }

        if (PlayerPrefs.GetInt("VeicleId") == 3 && PlayerPrefs.GetInt("QtnFoodtruck") > 0)
        {
            customersInstance.timeToInstantiate = 5;
        }
    }
}
