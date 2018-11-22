using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour {

    private bool gameIsPaused = false;
    [SerializeField]private GameObject pauseMenuUI;

    

    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown("Pause"))
        {
            Debug.Log("pause");
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
    }

    void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }


}
