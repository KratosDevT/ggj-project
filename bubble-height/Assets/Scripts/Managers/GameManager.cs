using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject playerGameObject;
    [SerializeField] private GameObject backGroundGameObject;
    [SerializeField] private GameObject spawnerGameObject;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject endText;

    private static GameManager istance;

    private static float playerVelocityX;
    private static int playerLife = 10;


    private BackgroundController backgroundController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        istance = this;
        backgroundController = backGroundGameObject.GetComponent<BackgroundController>();
    }

    void Update()
    {
        if (getDifficulty() == 5)
        {
            GameEndWin();
        }
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
        istance.canvas.SetActive(true);
        istance.PauseGame();
        AudioManager.Play(0);
    }

    private static void GameEndWin()
    {
        istance.PauseGame();
        AudioManager.PlayLoop(0);
        ObstaclePauser.DestroyElemets();
        Destroy(istance.playerGameObject);
        AudioManager.Play(1);
        ProcessWinCondition();
    }

    private static void ProcessWinCondition()
    {
        istance.endText.SetActive(true);
    }

    public void PlayAgain()
    {
        ObstaclePauser.DestroyElemets();
        istance.canvas.SetActive(false);
        backgroundController.setBackgroundStartPosition();
        playerLife = 10;
        istance.UnPauseGame();
        playerGameObject.transform.position = new Vector3(0, playerGameObject.transform.position.y, 0);
        playerGameObject.GetComponent<CharacterMovement>().GenerateBubbles(10);
    }

    private void PauseGame()
    {
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
        return istance.backgroundController.getCurrentStage();
    }
}
