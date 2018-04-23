using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicIngame : MonoBehaviour {

    public AudioClip[] musicsCreepy;
    public AudioClip[] musicsPsy;

    private AudioSource sourceCreepy;
    private AudioSource sourcePsy;

	// Use this for initialization
	void Start () {
        sourceCreepy = GameObject.Find("MusicPlayerCreepy").GetComponent<AudioSource>();
        sourcePsy = GameObject.Find("MusicPlayerPsy").GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        if(Game.LevelFinished) {
            sourceCreepy.Stop();
            if(!sourcePsy.isPlaying) {
                playRandomMusic();
            }
        }

        else {
            sourcePsy.Stop();
            if (!sourceCreepy.isPlaying) {
                playRandomMusic();
            }
        }
    }

    void playRandomMusic() {
        if(Game.LevelFinished) {
            sourcePsy.PlayOneShot(musicsPsy[Random.Range(0, musicsPsy.Length)]);
        }
        else {
            sourceCreepy.PlayOneShot(musicsCreepy[Random.Range(0, musicsCreepy.Length)]);
        }
    }
}
