using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggers : MonoBehaviour {

    private LevelClass level;
    private PlayerMovements playerMovements;
    private float timeWhenCollision;
    private float timeCooldownOnCollision = 3f;
    private float levelSpeedSave;
    private float playerMovementSave;
    private Animator playerAnimator;
	
    public enum PlayerOnEnemyStates
    {
        NORMAL,
        ACCELERATION,

        //Ground enemies
        GROUND_ENEMY_HIT,
        STOP_TIME,
        END_STOP_TIME,
        

        //Garbage bin
        GARBAGE_BIN_HIT,
        DECELERATION,

        //Flying enemies

    }

    public PlayerOnEnemyStates playerState = PlayerOnEnemyStates.NORMAL;

	void Start () {
        level = FindObjectOfType<LevelClass>();
        playerMovements = FindObjectOfType<PlayerMovements>();
        playerAnimator = GetComponentInChildren<Animator>();
	}
	
	
	void Update () {
	switch (playerState)
        {
            case PlayerOnEnemyStates.NORMAL:
                
                break;
            case PlayerOnEnemyStates.GROUND_ENEMY_HIT:
                GroundEnemyHit();
                break;
            case PlayerOnEnemyStates.STOP_TIME:
                StopTime();
                break;
            case PlayerOnEnemyStates.END_STOP_TIME:
                EndStopTime();
                break;
            case PlayerOnEnemyStates.ACCELERATION:
                
                Acceleration();
                break;
            case PlayerOnEnemyStates.GARBAGE_BIN_HIT:
                
                GarbageBinHit();
                break;
            case PlayerOnEnemyStates.DECELERATION:
                Deceleration();
                break;

        }
	}

    void GroundEnemyHit()
    {
        levelSpeedSave = level.levelSpeed;
        playerMovementSave = playerMovements.playerMovementSpeed;
        level.levelSpeed = 0;
        playerMovements.playerMovementSpeed = 0;
        timeWhenCollision = Time.timeSinceLevelLoad;
        playerAnimator.SetBool("PlayerStopped", true);
        playerState = PlayerOnEnemyStates.STOP_TIME;

    }

    void StopTime()
    {
        if (Time.timeSinceLevelLoad - timeWhenCollision >= timeCooldownOnCollision)
        {
            playerState = PlayerOnEnemyStates.END_STOP_TIME;
        }
    }

    void EndStopTime()
    {
        playerAnimator.SetBool("PlayerStopped", false);
        playerAnimator.SetBool("PlayerInvincibility", true);
        playerState = PlayerOnEnemyStates.ACCELERATION;
    }

    void Acceleration()
    {
        level.levelSpeed = level.levelSpeed - level.playerAcceleration * Time.deltaTime;
        if (level.levelSpeed <= levelSpeedSave)
        {
            level.levelSpeed = levelSpeedSave;
            playerMovements.playerMovementSpeed = playerMovementSave;
            
            playerAnimator.SetBool("PlayerInvincibility", false);
            playerState = PlayerOnEnemyStates.NORMAL;
        }
    }

    private void GarbageBinHit()
    {
        levelSpeedSave = level.levelSpeed;
        playerMovementSave = playerMovements.playerMovementSpeed;
        playerMovements.playerMovementSpeed = 0;
        playerAnimator.SetBool("PlayerDecelerating", true);
        playerState = PlayerOnEnemyStates.DECELERATION;
    }

    private void Deceleration()
    {
        level.levelSpeed = level.levelSpeed + level.playerAcceleration * Time.deltaTime;
        if (level.levelSpeed >= 0)
        {
            level.levelSpeed = 0;
            playerAnimator.SetBool("PlayerDecelerating", false);
            playerAnimator.SetBool("PlayerInvincibility", true);
            playerState = PlayerOnEnemyStates.ACCELERATION;
        }
    }


}
