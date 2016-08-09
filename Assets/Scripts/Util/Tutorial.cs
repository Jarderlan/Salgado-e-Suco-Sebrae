using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour
{
    public TouchButton tutorialButton;
    public Animator tutorialAnimator;
    public int tutorialGuiIndex;
    public int tutorialId;

	void Start () 
    {
        tutorialGuiIndex = 9;
	}
	
	void Update ()
    {
        if(tutorialButton.canDo == 1)
        {
            tutorialId++;
            SoundController.PlaySound(SoundState.BUTTON_CLIC);
            tutorialButton.canDo = 0;
        }

        PlayTutorial(tutorialId);
	}

    void PlayTutorial(int animationId)
    {
        if(animationId == 1)
        {
            tutorialAnimator.Play("MapTutorial");
            tutorialGuiIndex = 10;
        }

        else if (animationId == 2)
        {
            tutorialAnimator.Play("MapTutorial_2");
            tutorialGuiIndex = 11;
        }

        else if (animationId == 3)
        {
            tutorialAnimator.Play("MapTutorial_3");
            tutorialGuiIndex = 12;
        }

        else if (animationId == 4)
        {
            tutorialAnimator.Play("MarketTutorial");
            tutorialGuiIndex = 13;
        }

        else if (animationId == 5)
        {
            tutorialAnimator.Play("MarketTutorial_2");
            tutorialGuiIndex = 14;
        }

        else if (animationId == 6)
        {
            tutorialAnimator.Play("MarketTutorial_3");
            tutorialGuiIndex = 15;
        }

        else if (animationId == 7)
        {
            tutorialAnimator.Play("TutorialFinal");
            tutorialGuiIndex = 16;
        }
    }
}
