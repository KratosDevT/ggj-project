using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject playerGameObject;
    [SerializeField] private GameObject backgroundGameObject;
    [SerializeField] private GameObject spawnerGameObject;
    [SerializeField] private GameObject winCanvas;
    [SerializeField] private GameObject loseCanvas;

    public static GameManager Instance { get; private set; }
    public GameState currentGameState { get; private set; }

    [SerializeField] private int playerCurrentLife;
    [SerializeField] private int playerMaxLife = 10;
    [SerializeField] private int currentStage = 0;
    [SerializeField] private float backgroundSpeed;
    private BackgroundController backgroundController;

    public enum GameState
    {
        StartMenu,
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
        playerCurrentLife = playerMaxLife;
        currentGameState = GameState.Playing;
        playerGameObject.GetComponent<CharacterController>().SetHp(playerCurrentLife);
    }

    void Start()
    {
        backgroundController = backgroundGameObject.GetComponent<BackgroundController>();
        backgroundSpeed = backgroundController.GetSpeedY();
    }

    void Update()
    {
        updateStage();
    }

    public void updateStage()
    {
        float currentY = backgroundGameObject.transform.position.y;
        float rangeForNextStage = backgroundController.GetRangeForStage(currentStage);

        if (currentY < rangeForNextStage)
        {
            currentStage += 1;
            Debug.Log("GM currentStage:" + currentStage);
        }
    }

    public void DamagePlayer(int damage)
    {
        playerCurrentLife -= damage;
        if (playerCurrentLife < 1) GameEnd();
        if (playerCurrentLife % 2 == 0) AudioManager.PlayLoop((playerCurrentLife / 2) + 1);
        AudioManager.Play(1);
    }

    private void GameEnd()
    {
        loseCanvas.SetActive(true);
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
        winCanvas.SetActive(true);
    }

    public void PlayAgain()
    {
        ObstaclePauser.DestroyElemets();
        loseCanvas.SetActive(false);
        winCanvas.SetActive(false);
        playerCurrentLife = playerMaxLife;
        UnPauseGame();
        playerGameObject.transform.position = new Vector3(0, playerGameObject.transform.position.y, 0);
        playerGameObject.GetComponent<CharacterController>().GenerateBubbles(10);
    }

    private void PauseGame()
    {
        ObstaclePauser.PauseElemets();
        spawnerGameObject.GetComponent<SpawnerScript>().disableSpawn();
        backgroundGameObject.GetComponent<BackgroundController>().setSpeedY(0);
        playerGameObject.GetComponent<CharacterController>().enabled = false;
    }

    private void UnPauseGame()
    {
        spawnerGameObject.GetComponent<SpawnerScript>().enableSpawn();
        playerGameObject.GetComponent<CharacterController>().enabled = true;
        backgroundGameObject.GetComponent<BackgroundController>().setSpeedY(backgroundSpeed);
    }

    public int GetStage()
    {
        return currentStage;
    }
}
