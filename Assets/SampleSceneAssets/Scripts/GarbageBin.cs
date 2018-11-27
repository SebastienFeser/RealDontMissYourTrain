using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageBin : MonoBehaviour {

/*
Check if the player hits the garbage bin.
*/

    private PlayerScript playerScript;

	void Start () {
        playerScript = FindObjectOfType<PlayerScript>();
    }
	

    private void OnTriggerEnter2D(Collider2D collision)
    {
      

        if (playerScript.playerState == PlayerScript.PlayerOnEnemyStates.NORMAL || playerScript.playerState == PlayerScript.PlayerOnEnemyStates.PUNCH) //Check if the player is in Punch or Normal state
            if (collision.gameObject.CompareTag("Player"))
        {
            playerScript.playerState = PlayerScript.PlayerOnEnemyStates.GARBAGE_BIN_HIT;
        }
    }

    
    
}
