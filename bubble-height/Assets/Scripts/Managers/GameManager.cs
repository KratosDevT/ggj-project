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
        currentHeight = backgroundController.getCurrentHeight();


    }

    void Update()
    {
        backgroundController.setSpeedY(backGroundVelocity);
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

        if (playerLife % 2 == 0) AudioManager.PlayLoop((playerLife / 2) + 1);

        AudioManager.Play(1);


        return playerLife;
    }

    private static void GameEnd()
    {
        istance.looseGameCanvas.SetActive(true);

        istance.PauseGame();

        AudioManager.Play(0);
    }

    private static void GameEndWin()
    {
        istance.PauseGame();
        AudioManager.PlayLoop(0);
    }

    public void PlayAgain()
    {
        ObstaclePauser.DestroyElemets();
        istance.looseGameCanvas.SetActive(false);
        backgroundController.setBackgroundStartPosition();
        playerLife = 10;
        stage = 0;
        istance.UnPauseGame();
        playerGameObject.GetComponent<CharacterMovement>().GenerateBubbles(10);
    }

    private void PauseGame() {
        ObstaclePauser.PauseElemets();
        spawnerGameObject.GetComponent<SpawnerScript>().disableSpawn();
        backgroundController.enabled = false;
        playerGameObject.GetComponent<CharacterMovement>().enabled = false;
    }

    private void UnPauseGame()
    {
        spawnerGameObject.GetComponent<SpawnerScript>().enableSpawn();
        backgroundController.enabled = true;
        playerGameObject.GetComponent<CharacterMovement>().enabled = true;
    }

    public static int getDifficulty()
    {
        return istance.getCurrentStage();
    }

    private int getCurrentStage()
    {
        if (currentHeight < bgHighLevels[stage])
        {
            ++stage;
        }
        return stage;
    }
}
