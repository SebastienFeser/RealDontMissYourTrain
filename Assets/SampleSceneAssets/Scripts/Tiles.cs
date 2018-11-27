using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour {
    /*
    Manages the tiles speed
    */
    [SerializeField]private Rigidbody2D actualTile;
    LevelClass actualLevel;
    

	void Start () {
        actualTile = GetComponent<Rigidbody2D>();
        actualLevel = FindObjectOfType<LevelClass>();
        actualTile.velocity = new Vector2(actualLevel.LevelSpeed, 0);
		
	}

	void FixedUpdate () {
        if (actualTile.velocity.x != actualLevel.LevelSpeed) //here to have better performances instead to check every time
        actualTile.velocity = new Vector2(actualLevel.LevelSpeed, 0);
    }
}
