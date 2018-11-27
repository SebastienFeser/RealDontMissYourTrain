using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelClass : MonoBehaviour {
    /*
     Contains the principal elements of the actual level and the map generator
     */

    #region Attributes
    private float countDown;    //Sets the actual level timer
    private float levelSpeed;   //Is the speed of the level, used by others scripts
    public List<GameObject> neededTilesList; //never used for now, here for future changes
    public List<GameObject> randomLevelTilesList; //List of gameobject tiles in the actual level
    private int levelSize;  //number of random tiles in the level
    [SerializeField]private float playerAcceleration = 8f; //used in player Script
    #endregion

    #region GetSetters For Attributes
    public float CountDown
    {
        get { return countDown; }
        set { countDown = value; }
    }


   public float LevelSpeed
    {
        
        get { return levelSpeed; }
        set { levelSpeed = value; }
    
    }

    public int LevelSize
    {
        get { return levelSize; }
        set { levelSize = value; }
    }

    public float PlayerAcceleration
    {
        get { return playerAcceleration; }
        set { playerAcceleration = value; }
    }
    #endregion

    public List<GameObject> MapGenerator ()
    {
        //(useless for now, possibly used in the future) Adding needed tiles in the level Map
        List<GameObject> LevelSizeList = new List<GameObject>();
        foreach (GameObject element in neededTilesList)
        {
            LevelSizeList.Add(element);
        }

        //Add the random tiles to the level
        int randomTileListSize = levelSize - neededTilesList.Count; //neededTilesList always = 0 (possibly changing in the future)
        for (int i=0; i < randomTileListSize; i++)          
        {
            int position = Random.Range (0, randomLevelTilesList.Count);
            LevelSizeList.Add(randomLevelTilesList[position]);
        }

            return LevelSizeList;
    } 

}
