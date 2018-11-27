using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour {
 /*
 Initializes the main music of the game   
 */

    public AudioSource mainMusicSource;
    [SerializeField] private AudioClip mainMusicClip;
    private bool playMusic = true;

    void Start () {
        mainMusicSource = GetComponent<AudioSource>();
        mainMusicSource.clip = mainMusicClip;
        mainMusicSource.Play();
        mainMusicSource.loop = playMusic;
    }
}
