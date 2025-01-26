using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject playerGameObject;
    [SerializeField] private GameObject backGroundGameObject;
    [SerializeField] private GameObject spawnerGameObject;
    [SerializeField] private GameObject looseGameCanvas;

    [SerializeField] private float[] bgHighLevels;
    [SerializeField] private float backGroundVelocity;
    [SerializeField] private float currentHeight = 0;
    [SerializeField] private int stage = 0;
    private static GameManager istance;

    private static float playerVelocityX;
    private static int playerLife = 10;


    private BackgroundController backgroundController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        istance = this;

        backgroundController = backGroundGameObject.GetComponent<BackgroundController>();

        AudioManager.Play(0);

        Button btn = looseGameCanvas.GetComponentInChildren<Button>();
        btn.onClick.AddListener(PlayAgain);

    }

    void Update()
    {
        backgroundController.setSpeed(backGroundVelocity);
        currentHeight = backgroundController.getCurrentHeight();

        if (getCurrentStage() == bgHighLevels.Length) GameEndWin();
    }

    public static float getPlayerVelocityX()
    {
        return playerVelocityX;
    }

    public static int PlayerIsHit()
    {
        if (--playerLife < 1) GameEnd();

        if (playerLife % 2 == 0) AudioManager.Play((playerLife % 2) + 2);

        return playerLife;
    }

    private static void GameEnd()
    {
        istance.looseGameCanvas.SetActive(true);

        AudioManager.Play((int) AudioManager.Song.loose);
    }

    private static void GameEndWin()
    {
        istance.StopGame();
        AudioManager.Play((int)AudioManager.Song.win);
    }

    public void PlayAgain() {
        istance.looseGameCanvas.SetActive(false);
        //Clear Obstacle
        //reset background
        istance.UnPauseGame();
    }

    private void StopGame()
    {
        spawnerGameObject.GetComponent<SpawnerScript>().disableSpawn();
        backGroundGameObject.SetActive(false);
        playerGameObject.SetActive(false);
    }

    private void UnPauseGame() {
        spawnerGameObject.GetComponent<SpawnerScript>().enableSpawn();
        backGroundGameObject.SetActive(true);
        playerGameObject.SetActive(true);
    }

    public static int getDifficulty()
    {
        return istance.getCurrentStage();
    }

    private int getCurrentStage()
    {
        if (currentHeight < bgHighLevels[stage]) {
            ++stage;
        }
        return stage;
    }
}
