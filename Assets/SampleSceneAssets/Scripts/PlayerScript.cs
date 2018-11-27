using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    private LevelClass level;
    private PlayerMovements playerMovements;
    private float timeWhenCollision;
    private float timeCooldownOnCollision = 3f;
    private float levelSpeedSave;
    private float playerMovementSave;
    private Animator playerAnimator;
    [SerializeField] private AudioClip footstepsAudio;
    [SerializeField] private AudioClip punch;
    public AudioSource playerAudioSource;
    private bool haveToLoop = true;     //used for sounds
    

    
    

    public enum PlayerOnEnemyStates
    {
        NORMAL,
        ACCELERATION,

        //Punch
        PUNCH,
        UNPUNCH,

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

    void Start() {
        level = FindObjectOfType<LevelClass>();
        playerMovements = FindObjectOfType<PlayerMovements>();
        playerAnimator = GetComponentInChildren<Animator>();
        playerAudioSource = GetComponent<AudioSource>();
    }


    void FixedUpdate() {

        Debug.Log(level.LevelSpeed);
        switch (playerState)
        {
            case PlayerOnEnemyStates.NORMAL:
                if (playerAudioSource.clip != footstepsAudio)
                {
                    playerAudioSource.clip = footstepsAudio;
                    playerAudioSource.Play();
                    playerAudioSource.loop = haveToLoop;
                }
                break;
            case PlayerOnEnemyStates.PUNCH: //Is activated when the player ispressing the punch key
                
                if (playerAudioSource.clip != punch)
                {
                    playerAudioSource.clip = punch;
                    playerAudioSource.Play();
                    playerAudioSource.loop = !haveToLoop;
                }
                Punch();
                break;
            case PlayerOnEnemyStates.UNPUNCH: //Is activated when the punch key is released if the player is punching
                
                if (playerAudioSource.clip != footstepsAudio)
                {
                    playerAudioSource.clip = footstepsAudio;
                    playerAudioSource.Play();
                    playerAudioSource.loop = haveToLoop;
                }
                UnPunch();
                break;
            case PlayerOnEnemyStates.GROUND_ENEMY_HIT:  //is activated when the player hits a human ennemy
                GroundEnemyHit();
                break;
            case PlayerOnEnemyStates.STOP_TIME:
                playerAudioSource.Stop();
                StopTime();
                break;
            case PlayerOnEnemyStates.END_STOP_TIME:
                EndStopTime();
                break;
            case PlayerOnEnemyStates.ACCELERATION:
                if (playerAudioSource.clip != footstepsAudio || !playerAudioSource.isPlaying)
                {
                    playerAudioSource.clip = footstepsAudio;
                    playerAudioSource.Play();
                }
                Acceleration();
                break;
            case PlayerOnEnemyStates.GARBAGE_BIN_HIT:   //is activated when the player hits a garbage bin
                playerAudioSource.Stop();
                GarbageBinHit();
                break;
            case PlayerOnEnemyStates.DECELERATION:
                Deceleration();
                break;

        }


    }

    void GroundEnemyHit()
    {
        levelSpeedSave = level.LevelSpeed;
        playerMovementSave = playerMovements.playerMovementSpeed;
        level.LevelSpeed = 0;
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
        level.LevelSpeed = level.LevelSpeed - level.PlayerAcceleration * Time.deltaTime;
        if (level.LevelSpeed <= levelSpeedSave)
        {
            level.LevelSpeed = levelSpeedSave;
            playerMovements.playerMovementSpeed = playerMovementSave;

            playerAnimator.SetBool("PlayerInvincibility", false);
            playerState = PlayerOnEnemyStates.NORMAL;
        }
    }

    private void GarbageBinHit()
    {
        playerAnimator.SetBool("PlayerPunching", false);
        levelSpeedSave = level.LevelSpeed;
        playerMovementSave = playerMovements.playerMovementSpeed;
        playerMovements.playerMovementSpeed = 0;
        playerAnimator.SetBool("PlayerDecelerating", true);
        playerState = PlayerOnEnemyStates.DECELERATION;
    }

    private void Deceleration()
    {
        level.LevelSpeed = level.LevelSpeed + level.PlayerAcceleration * Time.deltaTime;
        if (level.LevelSpeed >= 0)
        {
            level.LevelSpeed = 0;
            playerAnimator.SetBool("PlayerDecelerating", false);
            playerAnimator.SetBool("PlayerInvincibility", true);
            playerState = PlayerOnEnemyStates.ACCELERATION;
        }
    }

    private void Punch()
    {
        playerAnimator.SetBool("PlayerPunching", true);
        
    }

    private void UnPunch()
    {
        playerAnimator.SetBool("PlayerPunching", false);
        playerState = PlayerOnEnemyStates.NORMAL;
    }
   



}
