using UnityEngine;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour {

    [SerializeField] private GameObject playerGameObject;
    [SerializeField] private GameObject backGroundGameObject;
    [SerializeField] private GameObject audioManagerGameObject;

    [SerializeField] private float[] backGroundLevels;
    [SerializeField] private float backGroundVelocity;

    private static AudioSource audioSource;
    private static AudioManager audioManager;

    private static float currentHight = 0;
    private static float playerVelocityX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        //backGroundGameObject set velocity
        //get player velocity;
        audioSource = audioManagerGameObject.GetComponent<AudioSource>();
        audioManager = audioManagerGameObject.GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update() {
        currentHight += Time.deltaTime * backGroundVelocity;

       // audioSource.Play(audioManager.getAudioClip(getCurrentStage());


    }

    public static float getHight() {
        return currentHight;
    }

    public static float getPlayerVelocityX() {
        return playerVelocityX;
    }

    private int getCurrentStage() {
        int stage = 0;
        foreach(float backGroundLevel in backGroundLevels) {
            if (backGroundLevel > currentHight) break;
            ++stage;
        }
        return stage;
    }
}
