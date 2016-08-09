using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{
    [HideInInspector]
    public int canTakeMoney;
    private float currentTimeToDestroy;
    public float timeToDestroy;

    void Start()
    {
        transform.parent = GameObject.FindGameObjectWithTag("CoinParent").transform;
        SoundController.PlaySound(SoundState.SPAWN_COIN);
    }

    void Update()
    {
        currentTimeToDestroy += Time.deltaTime;

        if(currentTimeToDestroy > timeToDestroy)
        {
            Destroy(gameObject);
        }
    }

    void OnMouseDown()
    {
        if (GameController.GameControllerProperties.GetCurrentGameState() == GameState.PLAY)
        {
            SoundController.PlaySound(SoundState.COLLECT_COIN);
            canTakeMoney = 1;
            GetComponent<BoxCollider>().enabled = false;
            Destroy(gameObject);
        }
    }
}
