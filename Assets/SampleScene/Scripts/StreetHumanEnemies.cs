using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetHumanEnemies : MonoBehaviour {

    private LevelClass level;
    private PlayerMovements playerMovements;
    private float timeWhenCollision;
    private float timeCooldown = 3f;
    private float levelSpeedSave;
    private float playerMovementSave;

    private PlayerTriggers playerScript;
    enum StreetFundraiserState
    {
        NORMAL,
        
        //Punched States
        PUNCHED,
        STUN
    }

    StreetFundraiserState streetFundraiserState = StreetFundraiserState.NORMAL;


    // Use this for initialization
    void Start()
    {
        level = FindObjectOfType<LevelClass>();
        playerMovements = FindObjectOfType<PlayerMovements>();
        playerScript = FindObjectOfType<PlayerTriggers>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (streetFundraiserState)
        {
            case StreetFundraiserState.NORMAL:
                break;
            case StreetFundraiserState.PUNCHED:
                Punched();
                break;
            case StreetFundraiserState.STUN:
                Stun();
                break;
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (playerScript.playerState == PlayerTriggers.PlayerOnEnemyStates.NORMAL)
            {
                if (playerMovements.playerState == PlayerMovements.PlayerMovementState.NORMAL)
                {

                    playerScript.playerState = PlayerTriggers.PlayerOnEnemyStates.GROUND_ENEMY_HIT;
                }
                if (playerMovements.playerState == PlayerMovements.PlayerMovementState.PUNCH)
                {
                    streetFundraiserState = StreetFundraiserState.PUNCHED;
                }
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
