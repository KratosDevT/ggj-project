using UnityEngine;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour {

    [SerializeField] private GameObject playerGameObject;
    [SerializeField] private GameObject backGroundGameObject;
    [SerializeField] private GameObject audioManagerGameObject;
    [SerializeField] private GameObject spawnerGameObject;

    [SerializeField] private float[] backGroundLevels;
    [SerializeField] private float backGroundVelocity;

    private static GameManager instance;

    private static float currentHight = 0;
    private static float playerVelocityX;
    private static int playerLife = 10;

    private BackgroundController backgroundController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        instance = this;

        backgroundController = backGroundGameObject.GetComponent<BackgroundController>();
        //get player velocity;
    }

    void Update() {
        currentHight += Time.deltaTime * backGroundVelocity;

        backgroundController.setSpeed(backGroundVelocity)

        AudioManager.Play(0);

        if(getCurrentStage() == backGroundLevels.Length) GameEndWin();


    }

    public static float getHight() {
        return currentHight;
    }

    public static float getPlayerVelocityX() {
        return playerVelocityX;
    }

    public static int PlayerIsHit() {
        if (--playerLife < 1) GameEnd();

        if (playerLife % 2 == 0) AudioManager.Play(playerLife % 2);

        return playerLife;
    }

    private static void GameEnd() {

    }

    private static void GameEndWin() {

    }

    public static int getDifficulty() {
        return instance.getCurrentStage();
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
