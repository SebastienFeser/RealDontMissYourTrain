using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStreetEnnemies : MonoBehaviour {

    private LevelClass levelClass;
    private float actualSpeed = 0;          
    [SerializeField] private GameObject garbageBin;
    [SerializeField] private GameObject streetFundraiser;
    [SerializeField] private GameObject dealer;
    private Vector2 spawnPosition = new Vector2(11f, -2.6f);
    private bool canBeDestroyed = false; 
    private Vector2 enemySpawnDifference = new Vector2(0, 0.5f); //used to instantiate human ennemies at the right position
    private bool spawnCondition = true;
    private GameObject Enemy;

    void Start () {
        levelClass = FindObjectOfType<LevelClass>();

	}
	
	void FixedUpdate () {
        if (spawnCondition == true)
        {
            
            //Select Random ennemy
            Enemy = RandomEnemySelector(garbageBin, streetFundraiser, dealer);
            //Instantiate enemy at position
            EnemySpawn();
            
            
            spawnCondition = false;
        }
        //Check if EnemySpeed has to change
        if(levelClass.LevelSpeed != actualSpeed)
            GroundEnemySpeed(); //changes the enemy speed

        if (canBeDestroyed)
        {
            spawnCondition = true;
            canBeDestroyed = false;
            actualSpeed = 0;
            Destroy(Enemy);
        }

    }

    private GameObject RandomEnemySelector(GameObject Enemy1, GameObject Enemy2, GameObject Enemy3 )    //Selects randomly the enemy that have to spawn
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

    void EnemySpawn() //Spawn the enemy at the right position
    {
        if (Enemy == streetFundraiser || Enemy == dealer)
            Enemy = Instantiate(Enemy, spawnPosition + enemySpawnDifference, Quaternion.identity);
        else
            Enemy = Instantiate(Enemy, spawnPosition, Quaternion.identity);
    }

    void GroundEnemySpeed() //Gives the enemy a speed in function of the level speed, because the enemy isn't a child of the tile
    {
        Enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(levelClass.LevelSpeed, 0);
        
        actualSpeed = levelClass.LevelSpeed;
    }

    public bool CanRespawn
    {
        get { return canBeDestroyed; }
        set { canBeDestroyed = value; }
    }
}
