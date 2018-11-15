using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStreetEnnemies : MonoBehaviour {

    private LevelClass levelClass;
    private float actualSpeed = 0;          //Ici pour gagner en performance
    [SerializeField] private GameObject garbageBin;
    [SerializeField] private GameObject streetFundraiser;
    [SerializeField] private GameObject dealer;
    private Vector2 spawnPosition = new Vector2(11f, -2.6f);
    public bool canRespawn = false;
    private Vector2 enemySpawnDifference = new Vector2(0, 0.5f);
    private bool spawnCondition = true;
    private GameObject Enemy;

    // Use this for initialization
    void Start () {
        levelClass = FindObjectOfType<LevelClass>();
	}
	
	// Update is called once per frame
	void Update () {
        if (spawnCondition == true)
        {
            
            //Select Random ennemy if condition
            Enemy = RandomEnemySelector(garbageBin, streetFundraiser, dealer);
            //Instantiate enemy at position
            EnemySpawn();
            //
            
            
            spawnCondition = false;
        }
        //Check if EnemySpeed has to change
        if(levelClass.levelSpeed != actualSpeed)
            GroundEnemySpeed();

        if (canRespawn == true)
        {
            spawnCondition = true;
            canRespawn = false;
            actualSpeed = 0;
        }

    }

    GameObject RandomEnemySelector(GameObject Enemy1, GameObject Enemy2, GameObject Enemy3 )
    {
        GameObject EnemySelected = Enemy1;
        int caseSelector = Random.Range(0, 3);

        switch (caseSelector)
        {
            case 0:
                EnemySelected = Enemy1;
                break;
            case 1:
                EnemySelected = Enemy2;
                break;
            case 2:
                EnemySelected = Enemy3;
                break;
        }

        return EnemySelected;
    }

    void EnemySpawn()
    {
        if (Enemy == streetFundraiser || Enemy == dealer)
            Enemy = Instantiate(Enemy, spawnPosition + enemySpawnDifference, Quaternion.identity);
        else
            Enemy = Instantiate(Enemy, spawnPosition, Quaternion.identity);
    }

    void GroundEnemySpeed()
    {
        Enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(levelClass.levelSpeed, 0);
        
        actualSpeed = levelClass.levelSpeed;
    }
}
