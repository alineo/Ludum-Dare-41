using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {

    public AudioSource music;
    private bool musicMute;


    // Use this for initialization
    void Start () {
        musicMute = PlayerPrefs.GetString("muteSound").Equals("True");
        if (musicMute) music.Stop();
    }

    // Update is called once per frame
    void Update() {
        // if there is music
        if (!music.isPlaying && !musicMute) {
            music.Play();
            music.loop = true;
        }
    }

    public void startGame() {
        SceneManager.LoadScene("game");
    }

    public void options() {
        Debug.Log("Afficher les options");
    }

    public void quitGame() {
        Application.Quit();
    }

    // if there is music
    public void soundOn() {
        musicMute = false;
        PlayerPrefs.SetString("muteSound", musicMute.ToString());
    }

    public void soundOff() {
        musicMute = true;
        music.Stop();
        PlayerPrefs.SetString("muteSound", musicMute.ToString());
    }
}
