using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSounds : MonoBehaviour {

    public AudioClip[] sounds;

    private AudioSource source;
    private float lowVolume = .75F;
    private float highVolume = 1.25F;

	// Use this for initialization
	void Start () {
        source = GameObject.Find("Character").GetComponent<AudioSource>();

        StartCoroutine(PlaySound());
    }

    IEnumerator PlaySound() {

        while (Game.LevelFinished == false) {

            yield return new WaitForSecondsRealtime(Random.Range(15, 30));

            float volume = Random.Range(lowVolume, highVolume);
            source.PlayOneShot(sounds[Random.Range(0, sounds.Length)], volume);

        }
    }
}
