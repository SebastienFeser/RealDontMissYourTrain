using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dealer : MonoBehaviour {
    private LevelClass level;
    private PlayerMovements playerMovements;
    private bool collisionPlayerEvent = false;
    private bool initiateTime = false;
    private bool checkTime = false;
    private float timeWhenCollision;
    private float timeCooldown = 3f;
    private float levelSpeedSave;
    private float playerMovementSave;


	// Use this for initialization
	void Start () {
        level = FindObjectOfType<LevelClass>();
        playerMovements = FindObjectOfType<PlayerMovements>();
	}
	
	// Update is called once per frame
	void Update () {
        if (collisionPlayerEvent)
        {
            levelSpeedSave = level.levelSpeed;
            playerMovementSave = playerMovements.playerMovementSpeed;
            level.levelSpeed = 0;
            playerMovements.playerMovementSpeed = 0;
            //appear Text
            collisionPlayerEvent = false;
            initiateTime = true;
        }
        
        if (initiateTime)
        {
            timeWhenCollision = Time.timeSinceLevelLoad;
            initiateTime = false;
            checkTime = true;
        }
        if (checkTime)
        if (Time.timeSinceLevelLoad - timeWhenCollision >= timeCooldown)
        {
               
            level.levelSpeed = levelSpeedSave;
            playerMovements.playerMovementSpeed = playerMovementSave;
            checkTime = false;
        }
		
	}

    private void  OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {

            collisionPlayerEvent = true;
            
        }
    }
}
