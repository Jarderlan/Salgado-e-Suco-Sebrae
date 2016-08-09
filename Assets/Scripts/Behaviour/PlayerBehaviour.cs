using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerLocalPositions
{
    [Header("Local Level 1")]
    public Transform[] levelPositions;
    public TouchButton[] positionButtons;
    public Transform levelIndicator;
}

public class PlayerBehaviour : MonoBehaviour 
{
    public PlayerLocalPositions localsInstance;
    public int bonusPositionID;
    public SpawnCustomerController spawnCustomer;

	void Start () 
    {
        spawnCustomer = GameObject.FindGameObjectWithTag("SpawnCustomer").GetComponent<SpawnCustomerController>();
	}
	
	void Update () 
    {
        //mesh.material.color = Color.Lerp(mesh.material.color, new Color(195, 19, 191), 1 * Time.deltaTime);
        //mesh.material.color = Color.Lerp(mesh.material.color, Color.red, 1 * Time.deltaTime);

        if(GameController.GameControllerProperties.GetCurrentGameState() == GameState.MAP)
        {
            PlayerPositions();
        }
	}

    void PlayerPositions()
    {
        //level 1
        if (PlayerPrefs.GetInt("LevelId") == 0 || PlayerPrefs.GetInt("LevelId") == 1 || PlayerPrefs.GetInt("LevelId") == 2 || PlayerPrefs.GetInt("LevelId") == 3
        || PlayerPrefs.GetInt("LevelId") == 4 || PlayerPrefs.GetInt("LevelId") == 5 || PlayerPrefs.GetInt("LevelId") == 6
        || PlayerPrefs.GetInt("LevelId") == 7 || PlayerPrefs.GetInt("LevelId") == 8 || PlayerPrefs.GetInt("LevelId") == 9)
        {
            if (localsInstance.positionButtons[0].canDo == 1)
            {
                if (PlayerPrefs.GetInt("Tutorial") == 0)
                {
                    FindObjectOfType<Tutorial>().tutorialId++;
                }

                transform.position = localsInstance.levelPositions[0].transform.position;
                FindObjectOfType<CameraBehaviour>().cameraPositionsInstance.cameraPositionId = 0;
                spawnCustomer.MinAndMaxCustomers(50, 150);
                localsInstance.positionButtons[0].canDo = 0;
                SoundController.PlaySound(SoundState.TIC);
                bonusPositionID = 1;
            }
        }

        //level 2
        if (PlayerPrefs.GetInt("LevelId") == 1 || PlayerPrefs.GetInt("LevelId") == 2 || PlayerPrefs.GetInt("LevelId") == 3
        || PlayerPrefs.GetInt("LevelId") == 4 || PlayerPrefs.GetInt("LevelId") == 5 || PlayerPrefs.GetInt("LevelId") == 6
        || PlayerPrefs.GetInt("LevelId") == 7 || PlayerPrefs.GetInt("LevelId") == 8 || PlayerPrefs.GetInt("LevelId") == 9)
        {
            if (localsInstance.positionButtons[1].canDo == 1)
            {
                transform.position = localsInstance.levelPositions[1].transform.position;
                FindObjectOfType<CameraBehaviour>().cameraPositionsInstance.cameraPositionId = 1;
                spawnCustomer.MinAndMaxCustomers(150, 250);
                SoundController.PlaySound(SoundState.TIC);
                localsInstance.positionButtons[1].canDo = 0;
                bonusPositionID = 2;
            }

            if (localsInstance.positionButtons[2].canDo == 1)
            {
                transform.position = localsInstance.levelPositions[2].transform.position;
                FindObjectOfType<CameraBehaviour>().cameraPositionsInstance.cameraPositionId = 2;
                spawnCustomer.MinAndMaxCustomers(120, 180);
                SoundController.PlaySound(SoundState.TIC);
                localsInstance.positionButtons[2].canDo = 0;
                bonusPositionID = 1;
            }

            if (localsInstance.positionButtons[3].canDo == 1)
            {
                transform.position = localsInstance.levelPositions[3].transform.position;
                FindObjectOfType<CameraBehaviour>().cameraPositionsInstance.cameraPositionId = 3;
                spawnCustomer.MinAndMaxCustomers(50, 100);
                SoundController.PlaySound(SoundState.TIC);
                localsInstance.positionButtons[3].canDo = 0;
                bonusPositionID = 0;
            }
        }

        //level 3
        if (PlayerPrefs.GetInt("LevelId") == 2 || PlayerPrefs.GetInt("LevelId") == 3
        || PlayerPrefs.GetInt("LevelId") == 4 || PlayerPrefs.GetInt("LevelId") == 5 || PlayerPrefs.GetInt("LevelId") == 6
        || PlayerPrefs.GetInt("LevelId") == 7 || PlayerPrefs.GetInt("LevelId") == 8 || PlayerPrefs.GetInt("LevelId") == 9)
        {
            if (localsInstance.positionButtons[4].canDo == 1)
            {
                transform.position = localsInstance.levelPositions[4].transform.position;
                FindObjectOfType<CameraBehaviour>().cameraPositionsInstance.cameraPositionId = 4;
                spawnCustomer.MinAndMaxCustomers(200, 400);
                SoundController.PlaySound(SoundState.TIC);
                localsInstance.positionButtons[4].canDo = 0;
                bonusPositionID = 2;
            }

            if (localsInstance.positionButtons[5].canDo == 1)
            {
                transform.position = localsInstance.levelPositions[5].transform.position;
                FindObjectOfType<CameraBehaviour>().cameraPositionsInstance.cameraPositionId = 5;
                spawnCustomer.MinAndMaxCustomers(300, 450);
                SoundController.PlaySound(SoundState.TIC);
                localsInstance.positionButtons[5].canDo = 0;
                bonusPositionID = 0;
            }

            if (localsInstance.positionButtons[6].canDo == 1)
            {
                transform.position = localsInstance.levelPositions[6].transform.position;
                FindObjectOfType<CameraBehaviour>().cameraPositionsInstance.cameraPositionId = 6;
                spawnCustomer.MinAndMaxCustomers(20, 50);
                SoundController.PlaySound(SoundState.TIC);
                localsInstance.positionButtons[6].canDo = 0;
                bonusPositionID = 0;
            }
        }

        //level 4
        if (PlayerPrefs.GetInt("LevelId") == 3 || PlayerPrefs.GetInt("LevelId") == 4 || PlayerPrefs.GetInt("LevelId") == 5 || PlayerPrefs.GetInt("LevelId") == 6
        || PlayerPrefs.GetInt("LevelId") == 7 || PlayerPrefs.GetInt("LevelId") == 8 || PlayerPrefs.GetInt("LevelId") == 9)
        {
            if (localsInstance.positionButtons[7].canDo == 1)
            {
                transform.position = localsInstance.levelPositions[7].transform.position;
                FindObjectOfType<CameraBehaviour>().cameraPositionsInstance.cameraPositionId = 7;
                spawnCustomer.MinAndMaxCustomers(300, 450);
                SoundController.PlaySound(SoundState.TIC);
                localsInstance.positionButtons[7].canDo = 0;
                bonusPositionID = 2;
            }

            if (localsInstance.positionButtons[8].canDo == 1)
            {
                transform.position = localsInstance.levelPositions[8].transform.position;
                FindObjectOfType<CameraBehaviour>().cameraPositionsInstance.cameraPositionId = 8;
                spawnCustomer.MinAndMaxCustomers(250, 350);
                SoundController.PlaySound(SoundState.TIC);
                localsInstance.positionButtons[1].canDo = 8;
                bonusPositionID = 1;
            }

            if (localsInstance.positionButtons[9].canDo == 1)
            {
                transform.position = localsInstance.levelPositions[9].transform.position;
                FindObjectOfType<CameraBehaviour>().cameraPositionsInstance.cameraPositionId = 9;
                spawnCustomer.MinAndMaxCustomers(200, 250);
                SoundController.PlaySound(SoundState.TIC);
                localsInstance.positionButtons[9].canDo = 0;
                bonusPositionID = 0;
            }
        }

        //level 5
        if (PlayerPrefs.GetInt("LevelId") == 4 || PlayerPrefs.GetInt("LevelId") == 5 || PlayerPrefs.GetInt("LevelId") == 6
        || PlayerPrefs.GetInt("LevelId") == 7 || PlayerPrefs.GetInt("LevelId") == 8 || PlayerPrefs.GetInt("LevelId") == 9)
        {
            if (localsInstance.positionButtons[10].canDo == 1)
            {
                transform.position = localsInstance.levelPositions[10].transform.position;
                FindObjectOfType<CameraBehaviour>().cameraPositionsInstance.cameraPositionId = 10;
                spawnCustomer.MinAndMaxCustomers(250, 350);
                SoundController.PlaySound(SoundState.TIC);
                localsInstance.positionButtons[10].canDo = 0;
                bonusPositionID = 1;
            }

            if (localsInstance.positionButtons[11].canDo == 1)
            {
                transform.position = localsInstance.levelPositions[11].transform.position;
                FindObjectOfType<CameraBehaviour>().cameraPositionsInstance.cameraPositionId = 11;
                spawnCustomer.MinAndMaxCustomers(100, 150);
                SoundController.PlaySound(SoundState.TIC);
                localsInstance.positionButtons[11].canDo = 8;
                bonusPositionID = 0;
            }
        }

        //level 6
        if (PlayerPrefs.GetInt("LevelId") == 5 || PlayerPrefs.GetInt("LevelId") == 6
        || PlayerPrefs.GetInt("LevelId") == 7 || PlayerPrefs.GetInt("LevelId") == 8 || PlayerPrefs.GetInt("LevelId") == 9)
        {
            if (localsInstance.positionButtons[12].canDo == 1)
            {
                transform.position = localsInstance.levelPositions[12].transform.position;
                FindObjectOfType<CameraBehaviour>().cameraPositionsInstance.cameraPositionId = 12;
                spawnCustomer.MinAndMaxCustomers(300, 500);
                SoundController.PlaySound(SoundState.TIC);
                localsInstance.positionButtons[12].canDo = 0;
                bonusPositionID = 2;
            }

            if (localsInstance.positionButtons[13].canDo == 1)
            {
                transform.position = localsInstance.levelPositions[13].transform.position;
                FindObjectOfType<CameraBehaviour>().cameraPositionsInstance.cameraPositionId = 13;
                spawnCustomer.MinAndMaxCustomers(200, 350);
                SoundController.PlaySound(SoundState.TIC);
                localsInstance.positionButtons[13].canDo = 8;
                bonusPositionID = 0;
            }
        }

        //level 7
        if (PlayerPrefs.GetInt("LevelId") == 6 || PlayerPrefs.GetInt("LevelId") == 7 
        || PlayerPrefs.GetInt("LevelId") == 8 || PlayerPrefs.GetInt("LevelId") == 9)
        {
            if (localsInstance.positionButtons[14].canDo == 1)
            {
                transform.position = localsInstance.levelPositions[14].transform.position;
                FindObjectOfType<CameraBehaviour>().cameraPositionsInstance.cameraPositionId = 14;
                spawnCustomer.MinAndMaxCustomers(400, 500);
                SoundController.PlaySound(SoundState.TIC);
                localsInstance.positionButtons[14].canDo = 0;
                bonusPositionID = 2;
            }

            if (localsInstance.positionButtons[15].canDo == 1)
            {
                transform.position = localsInstance.levelPositions[15].transform.position;
                FindObjectOfType<CameraBehaviour>().cameraPositionsInstance.cameraPositionId = 15;
                spawnCustomer.MinAndMaxCustomers(300, 400);
                SoundController.PlaySound(SoundState.TIC);
                localsInstance.positionButtons[15].canDo = 8;
                bonusPositionID = 1;
            }

            if (localsInstance.positionButtons[16].canDo == 1)
            {
                transform.position = localsInstance.levelPositions[16].transform.position;
                FindObjectOfType<CameraBehaviour>().cameraPositionsInstance.cameraPositionId = 16;
                spawnCustomer.MinAndMaxCustomers(200, 350);
                SoundController.PlaySound(SoundState.TIC);
                localsInstance.positionButtons[16].canDo = 8;
                bonusPositionID = 0;
            }
        }

        //level 8
        if (PlayerPrefs.GetInt("LevelId") == 7 || PlayerPrefs.GetInt("LevelId") == 8 || PlayerPrefs.GetInt("LevelId") == 9)
        {
            if (localsInstance.positionButtons[17].canDo == 1)
            {
                transform.position = localsInstance.levelPositions[17].transform.position;
                FindObjectOfType<CameraBehaviour>().cameraPositionsInstance.cameraPositionId = 17;
                spawnCustomer.MinAndMaxCustomers(400, 500);
                SoundController.PlaySound(SoundState.TIC);
                localsInstance.positionButtons[17].canDo = 8;
                bonusPositionID = 2;
            }

            if (localsInstance.positionButtons[18].canDo == 1)
            {
                transform.position = localsInstance.levelPositions[18].transform.position;
                FindObjectOfType<CameraBehaviour>().cameraPositionsInstance.cameraPositionId = 18;
                spawnCustomer.MinAndMaxCustomers(200, 400);
                SoundController.PlaySound(SoundState.TIC);
                localsInstance.positionButtons[18].canDo = 8;
                bonusPositionID = 0;
            }
        }

        //level 9
        if (PlayerPrefs.GetInt("LevelId") == 8 || PlayerPrefs.GetInt("LevelId") == 9)
        {
            if (localsInstance.positionButtons[19].canDo == 1)
            {
                transform.position = localsInstance.levelPositions[19].transform.position;
                FindObjectOfType<CameraBehaviour>().cameraPositionsInstance.cameraPositionId = 19;
                spawnCustomer.MinAndMaxCustomers(400, 500);
                SoundController.PlaySound(SoundState.TIC);
                localsInstance.positionButtons[19].canDo = 8;
                bonusPositionID = 2;
            }

            if (localsInstance.positionButtons[20].canDo == 1)
            {
                transform.position = localsInstance.levelPositions[20].transform.position;
                FindObjectOfType<CameraBehaviour>().cameraPositionsInstance.cameraPositionId = 20;
                spawnCustomer.MinAndMaxCustomers(300, 400);
                SoundController.PlaySound(SoundState.TIC);
                localsInstance.positionButtons[20].canDo = 8;
                bonusPositionID = 1;
            }

            if (localsInstance.positionButtons[21].canDo == 1)
            {
                transform.position = localsInstance.levelPositions[21].transform.position;
                FindObjectOfType<CameraBehaviour>().cameraPositionsInstance.cameraPositionId = 21;
                spawnCustomer.MinAndMaxCustomers(200, 350);
                SoundController.PlaySound(SoundState.TIC);
                localsInstance.positionButtons[21].canDo = 8;
                bonusPositionID = 0;
            }
        }

        //level 10
        if (PlayerPrefs.GetInt("LevelId") == 9)
        {
            if (localsInstance.positionButtons[22].canDo == 1)
            {
                transform.position = localsInstance.levelPositions[22].transform.position;
                FindObjectOfType<CameraBehaviour>().cameraPositionsInstance.cameraPositionId = 22;
                spawnCustomer.MinAndMaxCustomers(300, 400);
                SoundController.PlaySound(SoundState.TIC);
                localsInstance.positionButtons[22].canDo = 8;
                bonusPositionID = 1;
            }

            if (localsInstance.positionButtons[23].canDo == 1)
            {
                transform.position = localsInstance.levelPositions[23].transform.position;
                FindObjectOfType<CameraBehaviour>().cameraPositionsInstance.cameraPositionId = 23;
                spawnCustomer.MinAndMaxCustomers(300, 400);
                SoundController.PlaySound(SoundState.TIC);
                localsInstance.positionButtons[23].canDo = 8;
                bonusPositionID = 1;
            }
        }

        localsInstance.levelIndicator.position = Vector2.Lerp(localsInstance.levelIndicator.position, localsInstance.positionButtons[FindObjectOfType<CameraBehaviour>().cameraPositionsInstance.cameraPositionId].transform.position, 2 * Time.deltaTime);
    }
}
