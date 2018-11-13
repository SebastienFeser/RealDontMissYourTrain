using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBackgroundSpawn : MonoBehaviour {
     float vitesse = 0;
    public float Vitesse
    {
        get { return vitesse; }
        set { vitesse = value;
        }
    }
	// Use this for initialization
	void Start () {
        Vitesse = 10;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
