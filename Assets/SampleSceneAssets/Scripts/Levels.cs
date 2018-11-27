using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour {
    [SerializeField] private int actualLevel;   //identifies the actual level, useless for now, because there's only 1 level
    [SerializeField] private GameObject beginningTile;
    [SerializeField] private GameObject endTile;
    private LevelClass levelClass;

    [SerializeField] private SpriteRenderer tileSprite; //Only one sprite renderer for the entire map
    private float tileSize;         
    private float tileScaleModifier = 1.4f;


    //Used to scroll the background
    private GameObject spawningTile;    //Tile that will be instantiate
    private GameObject actualTile;      //Displayed tile (right one), non destroyable 
    private GameObject destroyableTile; //Displayed tile (left one), destroyable 
    private List<GameObject> Map;       //actual level map
    private int mapListIndex = 0;       //Used to scroll the level and to select tiles


    [SerializeField]private GameObject[] Level1Tiles; 
    [SerializeField]private float level1countDown;
    [SerializeField]private float level1Speed;
    [SerializeField]private int level1Size;

    private float tileSpawnPosition = -34f;
    private float tileDestroyPosition = -55f;

    void Start () {

        levelClass = GetComponent<LevelClass>();
        //Level 1
        actualLevel = 1;
        if (actualLevel == 1)
        {
            levelClass.CountDown = level1countDown;
            levelClass.LevelSpeed = level1Speed;
            levelClass.randomLevelTilesList = new List<GameObject>();

            
            //Ajout des randomtiles du niveau 1 dans le randomleveltile

            foreach (GameObject Level1Tiles in Level1Tiles)
            {

                levelClass.randomLevelTilesList.Add(Level1Tiles);
            }
            levelClass.LevelSize = level1Size;
            
            


        }
        //Level 2
        //Level 3
        //Level 4
        //Level 5
        //Level boss

        //Generate Map
        tileSize = tileSprite.size.x;
        Map = levelClass.MapGenerator();
        //SpawnTile
       

        actualTile = Instantiate(beginningTile);

        
        
    }
	
	// In the update for better transitions
	void Update ()
    {
        

        if (mapListIndex <= levelClass.LevelSize)   //Check that the mapListIndex is in the bounds of the list
        {
            
            if (actualTile.transform.position.x <= tileSpawnPosition) //Check if the position of the actual tile is higher than the spawn position, to instantiate the new tile
            {
                //Create gameobject at same position + size of tiles for the x;
                //Need to create in scene spawningTile
                if (mapListIndex == levelClass.LevelSize) // check if the actual tile is the last tile of the map, if it's, it instantiates the end tile
                {
                    spawningTile = Instantiate(endTile);
                    spawningTile.transform.position = new Vector2(actualTile.transform.position.x + tileSize * tileScaleModifier, actualTile.transform.position.y);
                    destroyableTile = actualTile;
                    actualTile = spawningTile;
                    mapListIndex++;
                    
                }
                else    //instantiates the next tile
                {
                    spawningTile = Instantiate(Map[mapListIndex]);
                    spawningTile.transform.position = new Vector2(actualTile.transform.position.x + tileSize * tileScaleModifier, actualTile.transform.position.y);
                    destroyableTile = actualTile;
                    actualTile = spawningTile;
                    mapListIndex = mapListIndex + 1;
                }
            }
            if (destroyableTile == null); //does nothing if there's no destroyable tile
            else if (destroyableTile.transform.position.x <= tileDestroyPosition)   //Destroy tile
            {
                Destroy(destroyableTile);
            }

            
        }

        if (actualTile.transform.position.x <= tileSpawnPosition && levelClass.LevelSpeed != 0) //Stops the speed of the end tile and load Victory screen
        {
            levelClass.LevelSpeed = 0; //Not really useful for now
            SceneManager.LoadScene("Victory");

        }
		
	}
}
