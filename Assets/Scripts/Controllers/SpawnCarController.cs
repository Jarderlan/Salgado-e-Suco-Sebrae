using UnityEngine;
using System.Collections;

public class SpawnCarController : MonoBehaviour
{
    public GameObject carPrefab;
    public Transform[] carPositions;
    private int sortPosition;
    private float currentTime;
    public float timeToInstantiateCar;

	void Start ()
    {

	}
	
	void Update () 
    {
	    if(GameController.GameControllerProperties.GetCurrentGameState() == GameState.PLAY)
        {
            currentTime += Time.deltaTime;

            if(currentTime > timeToInstantiateCar)
            {
                sortPosition = Random.Range(0, carPositions.Length);
                InstantiateCar(carPrefab, carPositions[sortPosition], sortPosition);
                currentTime = 0;
            }
        }
	}

    void InstantiateCar(GameObject carPrefab, Transform carPosition, int sortPosition)
    {
        GameObject tempCar = Instantiate(carPrefab, carPosition.position, carPosition.rotation) as GameObject;

        if (sortPosition == 0)
        {
            if (tempCar != null)
            {
                tempCar.GetComponent<CarBehaviour>().speed = 0.3f;
                tempCar.GetComponent<CarBehaviour>().timeToGo += 1f;
            }
        }

        else if (sortPosition == 1)
        {
            if (tempCar != null)
            {
                tempCar.GetComponent<CarBehaviour>().speed = 0.7f;
            }
        }

        //else if (sortPosition == 2)
        //{
        //    if (tempCar != null)
        //    {
        //        //tempCar.GetComponent<CarBehaviour>().speed = 0.9f;
        //    }
        //}

        //else
        //{
        //    if (tempCar != null)
        //    {
        //        //tempCar.GetComponent<CarBehaviour>().speed = 1.1f;
        //    }
        //}
    }
}
