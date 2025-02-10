using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject playerGameObject;
    [SerializeField] private BackgroundController backGroundGameObject;
    [SerializeField] private GameObject spawnerGameObject;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject endText;

    public static GameManager Instance { get; private set; }
    public GameState currentGameState { get; private set; }
    public bool isGameOver { get; private set; }
    public float playerVelocityX { get; private set; }
    private int playerLife = 10;
    [SerializeField] private int stage = 0;
    public enum GameState
    {
        Menu,
        Playing,
        Paused,
        GameOver
    }

    private void Awake()
    {
        // Implementazione Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        InitializeGame();
    }

    private void InitializeGame()
    {
        currentGameState = GameState.Playing;
        isGameOver = false;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void Update()
    {
        updateStage();
        Debug.Log(stage);
    }

    public void updateStage()
    {
        // Debug.Log("range:" + rangesToCheck[stage]);
        // Debug.Log("transform.position.y:" + this.gameObject.transform.position.y);
        //Debug.Log(this.gameObject.transform.position.y < rangesToCheck[stage]);
        if (backGroundGameObject.transform.position.y < backGroundGameObject.GetRangeForStage(stage))
        {
            stage++;
        }
    }

    public float getPlayerVelocityX()
    {
        return playerVelocityX;
    }

    public int PlayerIsHit()
    {
        if (--playerLife < 1) GameEnd();
        if (playerLife % 2 == 0) AudioManager.PlayLoop((playerLife / 2) + 1);
        AudioManager.Play(1);
        return playerLife;
    }

    private void GameEnd()
    {
        canvas.SetActive(true);
        PauseGame();
        AudioManager.Play(0);
    }

    private void GameEndWin()
    {
        PauseGame();
        AudioManager.PlayLoop(0);
        ObstaclePauser.DestroyElemets();
        Destroy(playerGameObject);
        AudioManager.Play(1);
        ProcessWinCondition();
    }

    private void ProcessWinCondition()
    {
        endText.SetActive(true);
    }

    public void PlayAgain()
    {
        ObstaclePauser.DestroyElemets();
        canvas.SetActive(false);
        //backGroundGameObject.GetComponent<BackgroundController>().setBackgroundStartPosition();
        playerLife = 10;
        UnPauseGame();
        playerGameObject.transform.position = new Vector3(0, playerGameObject.transform.position.y, 0);
        playerGameObject.GetComponent<CharacterMovement>().GenerateBubbles(10);
    }

    private void PauseGame()
    {
        ObstaclePauser.PauseElemets();
        spawnerGameObject.GetComponent<SpawnerScript>().disableSpawn();
        //backgroundController.enabled = false;
        playerGameObject.GetComponent<CharacterMovement>().enabled = false;
    }

    private void UnPauseGame()
    {
        spawnerGameObject.GetComponent<SpawnerScript>().enableSpawn();
        //backgroundController.enabled = true;
        playerGameObject.GetComponent<CharacterMovement>().enabled = true;
    }

    internal int GetStage()
    {
        return stage;
    }
}
