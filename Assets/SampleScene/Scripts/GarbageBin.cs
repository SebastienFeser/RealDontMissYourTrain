using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageBin : MonoBehaviour {

    private LevelClass level;
    private PlayerMovements playerMovements;
    private float levelSpeedSave;
    private float playerMovementSave;
   

    enum PlayerStates
    {
        NORMAL,
        HIT,
        DECELERATION,
        STOP,
        ACCELERATION
    }

    PlayerStates playerState = PlayerStates.NORMAL;

	// Use this for initialization
	void Start () {
        level = FindObjectOfType<LevelClass>();
        playerMovements = FindObjectOfType<PlayerMovements>();
    }
	
	// Update is called once per frame
	void Update () {
		switch (playerState)
        {
            case PlayerStates.NORMAL:
                break;
            case PlayerStates.HIT:
                Hit();
                break;
            case PlayerStates.DECELERATION:
                Deceleration();
                break;
            case PlayerStates.STOP:
                Stop();
                break;
            case PlayerStates.ACCELERATION:
                Acceleration();
                break;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Lol");
        if(collision.gameObject.CompareTag("Player"))
        {
            playerState = PlayerStates.HIT;
        }
    }

    private void Hit()
    {
        levelSpeedSave = level.levelSpeed;
        playerMovementSave = playerMovements.playerMovementSpeed;
        playerMovements.playerMovementSpeed = 0;
        playerState = PlayerStates.DECELERATION;
    }

    private void Deceleration()
    {
        level.levelSpeed = level.levelSpeed + 8f * Time.deltaTime;
        if (level.levelSpeed >= 0)
        {
            level.levelSpeed = 0;
            playerState = PlayerStates.STOP;
        }
    }

    private void Stop()
    {
        playerState = PlayerStates.ACCELERATION;
    }

    private void Acceleration()
    {
        level.levelSpeed = level.levelSpeed - 8f * Time.deltaTime;
        if (level.levelSpeed <= levelSpeedSave)
        {
            level.levelSpeed = levelSpeedSave;
            playerMovements.playerMovementSpeed = playerMovementSave;
            playerState = PlayerStates.NORMAL;
        }
    }
    
}
