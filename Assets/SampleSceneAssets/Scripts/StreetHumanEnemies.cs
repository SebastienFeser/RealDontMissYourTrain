using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetHumanEnemies : MonoBehaviour {

    private LevelClass level;
    private PlayerMovements playerMovements;
    private PlayerScript playerTriggers;
    private float timeWhenCollision;
    private float timeCooldown = 3f;
    private float levelSpeedSave;   //saves the level speed, used when it's changed
    private float playerMovementSave;   //saves player movements, used when it's changed

    private AudioSource HumanEnemiesAudioSource;
    [SerializeField] private AudioClip helloAudio;
    [SerializeField] private AudioClip grunt;

    private PlayerScript playerScript;
    enum StreetFundraiserState
    {
        NORMAL,
        
        //Punched States
        PUNCHED,
        STUN
    }

    StreetFundraiserState streetFundraiserState = StreetFundraiserState.NORMAL;


    void Start()
    {
        level = FindObjectOfType<LevelClass>();
        playerMovements = FindObjectOfType<PlayerMovements>();
        playerScript = FindObjectOfType<PlayerScript>();
        HumanEnemiesAudioSource = GetComponent<AudioSource>();
        playerTriggers = FindObjectOfType<PlayerScript>();
    }

    void FixedUpdate()
    {
        switch (streetFundraiserState)
        {
            case StreetFundraiserState.NORMAL:
                break;
            case StreetFundraiserState.PUNCHED: //useless state for now
                Punched();
                break;
            case StreetFundraiserState.STUN:    //useless state for now
                Stun();
                break;
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) //Changes the player state or enemy state in function of the player state (and play sounds)
        {
            
                if (playerTriggers.playerState == PlayerScript.PlayerOnEnemyStates.NORMAL)
                {
                    HumanEnemiesAudioSource.clip = helloAudio;
                    HumanEnemiesAudioSource.Play();
                    playerScript.playerState = PlayerScript.PlayerOnEnemyStates.GROUND_ENEMY_HIT;
                }
                if (playerTriggers.playerState == PlayerScript.PlayerOnEnemyStates.PUNCH)
                {
                    HumanEnemiesAudioSource.clip = grunt;
                    HumanEnemiesAudioSource.Play();
                    streetFundraiserState = StreetFundraiserState.PUNCHED;
                }
            
        }
    }

    void Punched()
    {
        streetFundraiserState = StreetFundraiserState.STUN;
    }

    void Stun()
    {

    }
}
