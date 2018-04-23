using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour {

    public static Player player;

    public AudioClip pickSound;
    public AudioClip dropSound;

    private AudioSource source;
    
    private GameObject hitObject;

    private static GameObject robot;
    private static GameObject witch;
    private static GameObject mom;
    private static GameObject lava;

    private GameObject pile;
    private GameObject torchLamp;

    private RaycastHit hit;
    private Ray ray;
    private Vector3 fwd;

    public static int Level;

    public static bool LevelFinished;

    private static bool actionPossible;

    private static Text infoText;

    private static GameObject nextLevelButton;
    private static GameObject restartLevelButton;

    private static textInformationAnimation textAnimation;
    private static RectTransform canvas;

    // objects for level 5
    private GameObject level5GroupObjects;

    // Use this for initialization
    void Start () {
        Time.timeScale = 1f;
        textAnimation = Resources.Load<textInformationAnimation>("Animations/Text/PopupTextHolderObject");
        LevelFinished = false;
        infoText = GameObject.Find("informationText").GetComponent<Text>();
        canvas = GameObject.Find("Canvas").GetComponent<RectTransform>();
        nextLevelButton = GameObject.Find("nextLevelButton");
        nextLevelButton.SetActive(false);
        restartLevelButton = GameObject.Find("restartLevelButton");
        restartLevelButton.SetActive(false);
        level5GroupObjects = GameObject.Find("Level5");
        level5GroupObjects.SetActive(false);

        source = GameObject.Find("Character").GetComponent<AudioSource>();

        actionPossible = false;

        player = new Player();
        hitObject = null;
        Level = PlayerPrefs.GetInt("Level");
        Debug.Log("Commencement du niveau " + Level);

        robot = GameObject.Find("Robot");
        witch = GameObject.Find("Witch");
        mom = GameObject.Find("Mom");
        lava = GameObject.Find("LavaFloorUp");
        robot.SetActive(false);
        witch.SetActive(false);
        mom.SetActive(false);
        lava.SetActive(false);

        
        pile = GameObject.Find("Pile");
        pile.SetActive(false);

        torchLamp = GameObject.Find("TorchLamp");
        torchLamp.SetActive(false);

        // place the objects for the right level design
        if (Level == 1) {
            textInformationAnimation("Aaah! I had a nightmare, where is the light?\nOh right, on my nightstand, I better turn it on.\n(click 'e' near an object to try to interact with it)");
        } else if (Level == 2) { // robot
            textInformationAnimation("Bouhouu, again a nightmare... Let's turn on all the lights again, I don't want to stay in the dark...");
            Vector3 pos = GameObject.Find("LightSwitch").transform.position;
            GameObject.Find("LightSwitch").transform.position = new Vector3(pos.x, pos.y + 3, pos.z);
            robot.SetActive(true);
        }
        else if (Level == 3) { // witch
            textInformationAnimation("... Again... Oh no, my bedside lamp is broken and the torch is out of battery.\nI have to find new ones. It must be near my toys.\nWhaat, is that a witch ???");
            pile.SetActive(true);
            torchLamp.SetActive(true);
            GameObject.Find("BedsideLamp").transform.gameObject.tag = "Untagged";

            witch.SetActive(true);
        }
        else if (Level == 4) { // witch and robot
            textInformationAnimation("Ho no! Mom told me to clean my room last night but I forgot.\nQuick, let's hide my toys in my bed.");
            robot.SetActive(true);
            witch.SetActive(true);
        }
        else if (Level == 5) {
            textInformationAnimation("Wooow... Am I still dreaming? It's really hot in here.\nOh what's that light on top of my cabinet, let's find out!");
            lava.SetActive(true);
            level5GroupObjects.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update () {
        // the player try to pick up or drop an object
        if (Input.GetKeyDown("r")) {
            fwd = Camera.main.transform.rotation * Vector3.forward;
            
            ray = new Ray(transform.position, fwd);
            
            // an object was found in the raycast
            if (Physics.Raycast(ray, out hit, 3)) {
                // the player pick up the object
                hitObject = hit.collider.gameObject;
                Debug.Log("Object " + hitObject.name + " found");

                // the object found is pickable
                if (hitObject.tag == "pickable") {
                    Debug.Log("pickable object found");
                    source.PlayOneShot(pickSound, 1);
                    if (player.pickObject(hitObject)) {
                        if (hitObject.name == "pile") textInformationAnimation("Ah finally, I found the battery.\nI should bring them to my torch.");
                        hitObject.SetActive(false);
                        Debug.Log("Object : " + hitObject.name + " picked up");
                    }
                }
            } else {
                if (player.hasObject()) {
                    // drop object
                    hitObject = player.dropObject();
                    if (hitObject != null) {
                        Debug.Log("Object dropped");
                        source.PlayOneShot(dropSound, 1);
                        hitObject.transform.position = Camera.main.transform.rotation * Vector3.forward*2 + Camera.main.transform.position;
                    }
                }
            }
            hitObject = null;
        }
        else if (Input.GetKeyDown("return")) {
            if (actionPossible) {
                Debug.Log("action possible");
                if (nextLevelButton.activeSelf == true) {
                    nextLevel();
                }
                if (restartLevelButton.activeSelf == true) {
                    restartLevel();
                }
            }
        }
    }

    public static void finishLevel() {
        if (Level == 1) textInformationAnimation("Ah it's much better, now I can get back to sleep !");
        else if (Level == 2) textInformationAnimation("It was just my robot toy...\nLet's go back in bed before mom comes in.");
        else if (Level == 3) {
            textInformationAnimation("Mom : What happened here sweetie ? You ran away from me, is it a bad dream again ?\nYou will clean up your room tomorrow, it's a mess in here.");
        }
        else if (Level == 4) {
            textInformationAnimation("This room is so scary at night... I don't want to be here alone anymore.");
        }
        else if (Level == 5) {
            textInformationAnimation("Congratulation ! You braved all the danger.\nYou are a grown man now !");
            lava.SetActive(false);
            // return main menu
        }
        LevelFinished = true;
        AnimatorSwitchLight.TurnOnLight();
        if (Level == 2 || Level == 4) {
            robot.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
            robot.GetComponent<Ennemy_IA>().stop();
        }
        if (Level == 3 || Level == 4) {
            witch.SetActive(false);
            mom.SetActive(true);
        }


        GameObject.Find("armoire_porte_gauche").GetComponent<Animation>().enabled = false;
        GameObject.Find("armoire_porte_droite").GetComponent<Animation>().enabled = false;

        GameObject.Find("fenetre_gauche").GetComponent<Animation>().enabled = false;
        GameObject.Find("fenetre_droite").GetComponent<Animation>().enabled = false;
    }

    public static void Win() {
        nextLevelButton.SetActive(true);
        actionPossible = true;
    }

    public void nextLevel() {
        PlayerPrefs.SetInt("Level", Level+1);
        SceneManager.LoadScene("game");
    }

    public void restartLevel() {
        SceneManager.LoadScene("game");
    }

    public static void Lose() {
        Debug.Log("Joueur touché !");
        restartLevelButton.SetActive(true);
        actionPossible = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    public static void textInformationAnimation(string message) {
        Debug.Log(message);
        textInformationAnimation instance = Instantiate(textAnimation);
        instance.gameObject.SetActive(true);
        instance.transform.SetParent(canvas, false);
        instance.transform.SetAsLastSibling();
        if (message != null) instance.setText(message);
    }
}
