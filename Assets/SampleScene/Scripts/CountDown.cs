using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviour {
    LevelClass levelClass;
    float countDown;

	// Use this for initialization
	void Start () {
        levelClass = GetComponent<LevelClass>();

    }
	
	// Update is called once per frame
	void Update () {
        countDown = levelClass.countDown - Time.timeSinceLevelLoad;
        if (countDown <= 0)
        {
            countDown = 0;
            SceneManager.LoadScene("GameOver");
            
        }
        
		
	}


}
