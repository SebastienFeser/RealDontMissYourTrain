using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour {
    [SerializeField]private int actualLevel;
    [SerializeField] private GameObject[] Level1Tiles;
    [SerializeField] GameObject beginningTile;
    [SerializeField] GameObject endTile;
    List<GameObject> Map;
    LevelClass levelClass;

    [SerializeField] SpriteRenderer tileSizeSprite;
    float TileSize;


    //Utilisé pour scroll le background
    private GameObject spawningTile;
    private GameObject actualTile;
    private GameObject destroyableTile;
    private int i = 0;

    [SerializeField]private float level1countDown;
    [SerializeField]private float level1Speed;
    [SerializeField] private int level1Size;
    // Use this for initialization
    void Start () {
        levelClass = GetComponent<LevelClass>();
        //Level 1
        actualLevel = 1;
        if (actualLevel == 1)
        {
            levelClass.countDown = level1countDown;
            levelClass.levelSpeed = level1Speed;
            levelClass.randomLevelTilesList = new List<GameObject>();

            
            //Ajout des randomtiles du niveau 1 dans le randomleveltile

            foreach (GameObject Level1Tiles in Level1Tiles)
            {

                levelClass.randomLevelTilesList.Add(Level1Tiles);
            }
            levelClass.levelSize = level1Size;
            
            


        }
        //Level 2
        //Level 3
        //Level 4
        //Level 5
        //Level boss

        //Generate Map
        TileSize = tileSizeSprite.size.x;
        Map = new List<GameObject>();
        Map = levelClass.MapGenerator();
        //SpawnTile
       

        actualTile = Instantiate(beginningTile);

        
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        

        if (i <= levelClass.levelSize)
        {
            if (actualTile.transform.position.x <= -34 )
            {
                //Create gameobject at same position + size of tiles for the x;
                //Need to create in scene spawningTile
                if (i == levelClass.levelSize)
                {
                    spawningTile = Instantiate(endTile);
                    spawningTile.transform.position = new Vector2(actualTile.transform.position.x + TileSize * 1.4f, actualTile.transform.position.y);
                    destroyableTile = actualTile;
                    actualTile = spawningTile;
                    i++;
                    
                }
                else
                {
                    spawningTile = Instantiate(Map[i]);
                    spawningTile.transform.position = new Vector2(actualTile.transform.position.x + TileSize * 1.4f, actualTile.transform.position.y);
                    destroyableTile = actualTile;
                    actualTile = spawningTile;
                    i = i + 1;
                }
            }
            if (destroyableTile == null);
            else if (destroyableTile.transform.position.x <= -55)
            {
                Destroy(destroyableTile);
            }

            
        }

        if (actualTile.transform.position.x <= -34 && levelClass.levelSpeed != 0)
        {
            levelClass.levelSpeed = 0;
        }
		
	}
}
