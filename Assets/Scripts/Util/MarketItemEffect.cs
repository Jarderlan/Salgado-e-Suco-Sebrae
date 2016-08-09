using UnityEngine;
using System.Collections;

public class MarketItemEffect : MonoBehaviour 
{
    public TouchButton plusButton;
    public TouchButton minusButton;

    void Update()
    {
        if (GameController.GameControllerProperties.GetCurrentGameState() == GameState.MARKET)
        {
            if (plusButton.isOver || minusButton.isOver)
            {
                GetComponent<Animator>().Play("ItemOn");
            }

            else if (!plusButton.isOver && !minusButton.isOver)
            {
                GetComponent<Animator>().Play("ItemOff");
            }
        }        
    }
}
