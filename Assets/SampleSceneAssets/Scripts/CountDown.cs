using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

/*
 The script sets and displays the countDown of the game
*/

public class CountDown : MonoBehaviour {
    private LevelClass levelClass;
    private float countDown;
    [SerializeField] private TextMeshProUGUI countDownDisplayer;

	void Start () {
        levelClass = GetComponent<LevelClass>();
    }

    private void FixedUpdate() //Using FixedUpdate because time is Physics
    {
        countDown = levelClass.CountDown - Time.timeSinceLevelLoad;
        if (countDown <= 0)
        {
            //Load the Game Over screen if the player is out of time
            countDown = 0;
            SceneManager.LoadScene("GameOver");

        }
        countDownDisplayer.text = "Time Left: " + countDown.ToString("n1"); //Displays the time left on the game screen
    }


}
