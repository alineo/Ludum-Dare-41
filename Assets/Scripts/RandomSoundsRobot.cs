using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSoundsRobot : MonoBehaviour {

    public AudioClip[] robotSounds;

    private AudioSource source;
    private float lowVolume = .75F;
    private float highVolume = 1.25F;

    // Use this for initialization
    void Start() {
        source = GameObject.Find("Robot").GetComponent<AudioSource>();

        StartCoroutine(PlaySoundRobot());
    }

    IEnumerator PlaySoundRobot() {

        while (Game.LevelFinished == false) {

            yield return new WaitForSecondsRealtime(Random.Range(8, 15));

            float volume = Random.Range(lowVolume, highVolume);
            source.PlayOneShot(robotSounds[Random.Range(0, robotSounds.Length)], volume);

        }
    }
}
