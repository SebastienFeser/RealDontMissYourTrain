using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Manages the pause menu
*/
public class PauseScript : MonoBehaviour {

    private bool gameIsPaused = false;
    [SerializeField]private GameObject pauseMenuUI;
    private PlayerScript playerTriggers;
    private GameMusic gameMusic;
    private float pauseVolume = 0.3f;


    private void Start()
    {
        playerTriggers = FindObjectOfType<PlayerScript>();
        gameMusic = FindObjectOfType<GameMusic>();
    }
    
    void Update () {
        if (Input.GetButtonDown("Pause"))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

	}

    void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        playerTriggers.playerAudioSource.Play();
        gameMusic.mainMusicSource.volume = 1f;
    }

    void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        playerTriggers.playerAudioSource.Stop();
        gameMusic.mainMusicSource.volume = pauseVolume;
    }


}
