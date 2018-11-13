using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour {
    [SerializeField]private Rigidbody2D actualTile;
    LevelClass actualLevel;
    

	// Use this for initialization
	void Start () {
        actualTile = GetComponent<Rigidbody2D>();
        actualLevel = FindObjectOfType<LevelClass>();
       actualTile.velocity = new Vector2(actualLevel.levelSpeed, 0);
		
	}
	
	// Update is called once per frame
	void Update () {
        if (actualTile.velocity.x != actualLevel.levelSpeed)
        actualTile.velocity = new Vector2(actualLevel.levelSpeed, 0);
    }
}
