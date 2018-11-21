using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageBin : MonoBehaviour {

    private LevelClass level;
    private PlayerMovements playerMovements;
    private float levelSpeedSave;
    private float playerMovementSave;

    private PlayerTriggers playerScript;


	// Use this for initialization
	void Start () {
        level = FindObjectOfType<LevelClass>();
        playerMovements = FindObjectOfType<PlayerMovements>();
        playerScript = FindObjectOfType<PlayerTriggers>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerScript.playerState == PlayerTriggers.PlayerOnEnemyStates.NORMAL)
            if (collision.gameObject.CompareTag("Player"))
        {
            playerScript.playerState = PlayerTriggers.PlayerOnEnemyStates.GARBAGE_BIN_HIT;
        }
    }

    
    
}
