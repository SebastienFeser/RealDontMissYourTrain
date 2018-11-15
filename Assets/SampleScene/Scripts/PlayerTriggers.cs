using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggers : MonoBehaviour {

    [SerializeField] private GameObject garbageBin;
    [SerializeField] private GameObject streetFundraiser;
    [SerializeField] private GameObject dealer;
    [SerializeField] private LevelClass levelClass;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("collision");
        //Debug.Log(collision.gameObject);
        if(collision.gameObject == garbageBin.gameObject)
        {
            //levelClass.levelSpeed = 0f;
            Debug.Log("lol");
        }

        if(collision.gameObject == streetFundraiser.gameObject)
        {

        }

        if(collision.gameObject == dealer.gameObject)
        {

        }
            
    } */
}
