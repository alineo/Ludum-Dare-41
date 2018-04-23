using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSoundsWitch : MonoBehaviour {

    public AudioClip[] witchSounds;

    private AudioSource source;
    private float lowVolume = .5f;
    private float highVolume = 1F;

    // Use this for initialization
    void Start() {
        source = GameObject.Find("Witch").GetComponent<AudioSource>();

        StartCoroutine(PlaySoundWitch());
    }

    IEnumerator PlaySoundWitch() {

        while (Game.LevelFinished == false) {

            yield return new WaitForSecondsRealtime(Random.Range(Game.Level != 4 ? 8 : 13, Game.Level != 4 ? 15 : 25));

            float volume = Random.Range(lowVolume, highVolume);
            source.PlayOneShot(witchSounds[Random.Range(0, witchSounds.Length)], volume);

        }
    }
}
