using UnityEngine;
using System.Collections;

public class CarBehaviour : MonoBehaviour 
{
    public float speed;
    private float initialSpeed;
    private float currentTime;
    public float timeToGo;
    public bool startTime;

	void Start ()
    {
        initialSpeed = speed;
	}
	
	void Update ()
    {
	    if(GameController.GameControllerProperties.GetCurrentGameState() == GameState.PLAY)
        {
            if(startTime)
            {
                currentTime += Time.deltaTime;

                if(currentTime > timeToGo)
                {
                    speed = initialSpeed;
                }
            }

            transform.Translate(0, 0, speed * Time.deltaTime);

            if (transform.position.z < -4.5f || transform.position.x < -8f)
            {
                Destroy(gameObject);
            }
        }
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Npc")
        {
            speed = 0;
            startTime = true;
        }

        if (coll.gameObject.tag == "Car")
        {
            speed = 0;
            startTime = true;
        }
    }
}
