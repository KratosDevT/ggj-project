using UnityEngine;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject playerGameObject;
    [SerializeField] private GameObject backGroundGameObject;
    [SerializeField] private GameObject audioManagerGameObject;
    [SerializeField] private GameObject spawnerGameObject;

    [SerializeField] private float[] bgHighLevels;
    [SerializeField] private float backGroundVelocity;
    [SerializeField] private int stage = 0;

    private static GameManager instance;

    private static float currentHeight = 0;
    private static float playerVelocityX;
    private static int playerLife = 10;

    private BackgroundController backgroundController;

    void Start()
    {
        instance = this;
        backgroundController = backGroundGameObject.GetComponent<BackgroundController>();
        //get player velocity;
        AudioManager.Play(0);
    }

    void Update()
    {
        backgroundController.setSpeed(backGroundVelocity);
        currentHeight = backgroundController.getCurrentHeight();
        Debug.Log("stage:" + getCurrentStage());
        if (getCurrentStage() == bgHighLevels.Length)
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

        if (playerLife % 2 == 0) AudioManager.Play(playerLife % 2);

        return playerLife;
    }

    private static void GameEnd()
    {

    }

    private static void GameEndWin()
    {

    }

    public static int getDifficulty()
    {
        return instance.getCurrentStage();
    }

    private int getCurrentStage()
    {
        foreach (float bgHighLevel in bgHighLevels)
        {
            if (currentHeight > bgHighLevel) break;
            ++stage;
        }
        return stage;
    }
}
