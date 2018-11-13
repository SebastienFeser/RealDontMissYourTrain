using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelClass : MonoBehaviour {

    public float countDown;
    public float levelSpeed;
    public List<GameObject> neededTilesList;
    public List<GameObject> randomLevelTilesList;
    public int levelSize;
    //SpawnRules
    //Spawnable ennemies

    

    public List<GameObject> MapGenerator ()
    {
        //Ajout des tiles obligatoires
        List<GameObject> LevelSizeList = new List<GameObject>();
        foreach (GameObject element in neededTilesList)
        {
            LevelSizeList.Add(element);
        }

        //Ajout des tiles aléatoires
        int randomTileListSize = levelSize - neededTilesList.Count;
        for (int i=0; i < randomTileListSize; i++)
        {
            int position = Random.Range (0, randomLevelTilesList.Count);
            LevelSizeList.Add(randomLevelTilesList[position]);
        }

        //Mélange de la liste
       

        



            return LevelSizeList;
    } 

}
