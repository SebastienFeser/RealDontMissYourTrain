using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemies : MonoBehaviour {
    private LevelClass levelClass;
    [SerializeField] private GameObject pigeon;
    private bool spawnCondition = true;
    private Vector2 spawnPosition;
    [SerializeField] private float flyingEnemiesSpeed = 2f;
    private float flyingEnemiesSpeedBack;
    private GameObject enemy;
    private GameObject player;
    [SerializeField] private float fallingObjectsSpeed = 3f;

	// Use this for initialization
	void Start () {
        levelClass = FindObjectOfType<LevelClass>();
        spawnPosition = new Vector2(-11f,  4.3f);
        player = GameObject.FindGameObjectWithTag("Player");

    }
	
	// Update is called once per frame
	void Update () {
		if (spawnCondition == true)
        {
            EnemySpawn();
            FlyingEnemySpeed();
            spawnCondition = false;
            flyingEnemiesSpeedBack = -flyingEnemiesSpeed / 2;
        }

        if ((enemy.transform.position.y - player.transform.position.y) / fallingObjectsSpeed >= (enemy.transform.position.x - player.transform.position.x) / flyingEnemiesSpeedBack)
        {
            
            enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(levelClass.levelSpeed, 0);
        }

        if (enemy.transform.position.x < spawnPosition.x)
        {
            Destroy(enemy);
            spawnCondition = true;
        }

    }

    void EnemySpawn()
    {
        enemy = Instantiate(pigeon, spawnPosition, Quaternion.identity);
    }

    void FlyingEnemySpeed()
    {
        enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(flyingEnemiesSpeed, 0);

    }
         
}
