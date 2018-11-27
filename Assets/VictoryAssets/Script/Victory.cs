using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour {
    public AudioSource victorySource;
    [SerializeField] private AudioClip victoryClip;

    // Use this for initialization
    void Start () {
        victorySource = GetComponent<AudioSource>();
        victorySource.clip = victoryClip;
        victorySource.Play();
}
	
	// Update is called once per frame
	void Update () {
    
		
	}
}
