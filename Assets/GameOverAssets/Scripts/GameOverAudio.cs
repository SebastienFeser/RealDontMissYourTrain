using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverAudio : MonoBehaviour {
    public AudioSource gameOverSource;
    [SerializeField] private AudioClip gameOverClipMan;
    [SerializeField] private AudioClip gameOverClipGirl;

    // Use this for initialization
    void Start () {
        gameOverSource = GetComponent<AudioSource>();
        int soundSelector = Random.Range(0, 2);
        if (soundSelector == 1)
            gameOverSource.clip = gameOverClipMan;
        else
            gameOverSource.clip = gameOverClipGirl;
        gameOverSource.Play();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
