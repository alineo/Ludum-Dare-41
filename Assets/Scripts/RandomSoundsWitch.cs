using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSoundsWitch : MonoBehaviour {

    public AudioClip[] witchSounds;

    private AudioSource source;
    private float lowVolume = .75F;
    private float highVolume = 1.25F;

    // Use this for initialization
    void Start() {
        source = GameObject.Find("Witch").GetComponent<AudioSource>();

        StartCoroutine(PlaySoundWitch());
    }

    IEnumerator PlaySoundWitch() {

        while (Game.LevelFinished == false) {

            yield return new WaitForSecondsRealtime(Random.Range(8, 15));

            float volume = Random.Range(lowVolume, highVolume);
            source.PlayOneShot(witchSounds[Random.Range(0, witchSounds.Length)], volume);

        }
    }
}
