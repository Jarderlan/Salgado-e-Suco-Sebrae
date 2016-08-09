using UnityEngine;
using System.Collections;

public enum SoundState
{
    BUTTON_CLIC,
    SPAWN_COIN,
    COLLECT_COIN,
    TIC
}

public class SoundController : MonoBehaviour
{
    public static SoundController soundController;
    public AudioClip buttonClic;
    public AudioClip spawnCoin;
    public AudioClip collectCoin;
    public AudioClip tic;

    void Update()
    {

    }

	void Awake () 
    {
	    if(soundController == null)
        {
            soundController = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            DestroyImmediate(gameObject);
        }
	}
	
	public static void PlaySound (SoundState currentSoundState) 
    {
	    switch(currentSoundState)
        {
            case SoundState.BUTTON_CLIC:
                soundController.GetComponent<AudioSource>().PlayOneShot(soundController.buttonClic);
                break;

            case SoundState.SPAWN_COIN:
                soundController.GetComponent<AudioSource>().PlayOneShot(soundController.spawnCoin);
                break;

            case SoundState.COLLECT_COIN:
                soundController.GetComponent<AudioSource>().PlayOneShot(soundController.collectCoin);
                break;

            case SoundState.TIC:
                soundController.GetComponent<AudioSource>().PlayOneShot(soundController.tic);
                break;
        }
	}
}
