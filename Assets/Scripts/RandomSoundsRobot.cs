using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSoundsRobot : MonoBehaviour {

    public AudioClip[] robotSounds;

    private AudioSource source;
    private float lowVolume = .5F;
    private float highVolume = 1F;

    // Use this for initialization
    void Start() {
        source = GameObject.Find("Robot").GetComponent<AudioSource>();

        StartCoroutine(PlaySoundRobot());
    }

    IEnumerator PlaySoundRobot() {

        while (Game.LevelFinished == false) {

            yield return new WaitForSecondsRealtime(Random.Range(Game.Level != 4 ? 8 : 13, Game.Level != 4 ? 15 : 25));

            float volume = Random.Range(lowVolume, highVolume);
            source.PlayOneShot(robotSounds[Random.Range(0, robotSounds.Length)], volume);

        }
    }
}
