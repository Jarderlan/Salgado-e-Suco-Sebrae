using UnityEngine;
using System.Collections;

public class SaveController : MonoBehaviour
{
    private float currentTimeToSave;
    public UserService userService;
    public TouchButton saveButton;
    private LevelController levelController;
    
	void Start () 
    {
        levelController = GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelController>();
	}

    void SetHighScore(int score)
    {
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    void Update () 
    {
        //salvamento automatico servidor 30 minutos
        currentTimeToSave += Time.deltaTime;

        if(currentTimeToSave > 1800)
        {
            //userService.SetHighScore((int)levelController.score);
            SetHighScore((int)levelController.score);
            //userService.CallSendScore();
            currentTimeToSave = 0;
        }

        //salvamento clique botao save
        if(saveButton.canDo == 1 || levelController.currentTime > levelController.levelTime)
        {
            //userService.SetHighScore((int)levelController.score);
            SetHighScore((int)levelController.score);
            saveButton.canDo = 0;
        }
	}
}
