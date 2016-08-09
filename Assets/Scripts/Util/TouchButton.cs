using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
//[RequireComponent(typeof(Animator))]

public class TouchButton : MonoBehaviour
{
    [HideInInspector]
    public int canDo;
    public GameState gameState;
    public GameObject onSprite;
    public bool isOver;

    void Start()
    {
        if (onSprite != null)
        {
            onSprite.SetActive(false);
        }
    }
    
    void SetFalse()
    {
        canDo = 0;
        //GetComponent<BoxCollider>().enabled = true;
    }

    void OnMouseOver()
    {
        isOver = true;

        if (gameObject.tag == "HudButton" && GameController.GameControllerProperties.GetCurrentGameState() == gameState)
        {
            GetComponent<Animator>().SetBool("CanOver", true);
        }
    }

    void OnMouseExit()
    {
        isOver = false;

        if (gameObject.tag == "HudButton" && GameController.GameControllerProperties.GetCurrentGameState() == gameState)
        {
            GetComponent<Animator>().SetBool("CanOver", false);
        }
    }

    void OnMouseUp()
    {
        if (gameObject.tag == "HudButton")
        {
            if (GameController.GameControllerProperties.GetCurrentGameState() == gameState)
            {
                if (GetComponent<Animator>().GetBool("CanOver"))
                {
                    GetComponent<Animator>().SetBool("CanOver", false);
                }

                else
                {
                    GetComponent<Animator>().SetBool("CanOver", true);
                }
            }

            //pause e som
            if (gameObject.name == "pause_button" || gameObject.name == "sound_button")
            {
                if (onSprite != null)
                {
                    if (!onSprite.activeSelf)
                    {
                        onSprite.SetActive(true);
                    }

                    else
                    {
                        onSprite.SetActive(false);
                    }
                }
            }
        }

        else if(gameObject.tag == "Button")
        {
            GetComponent<Animator>().SetTrigger("Button");
        }

        canDo = 1;
        //GetComponent<BoxCollider>().enabled = false;
        Invoke("SetFalse", 0.1f);
    }
}
