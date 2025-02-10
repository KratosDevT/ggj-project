using System;
using UnityEngine;
using Color = UnityEngine.Color;
using Random = UnityEngine.Random;

public class SpawnerScript : MonoBehaviour
{

    [SerializeField] private GameObject[] obstaclesStage0;
    [SerializeField] private GameObject[] obstaclesStage1;
    [SerializeField] private GameObject[] obstaclesStage2;
    [SerializeField] private GameObject[] obstaclesStage3;
    [SerializeField] private GameObject[] obstaclesStage4;
    private GameObject[][] obstacles;
    [SerializeField] private bool canSpawn = true;
    [SerializeField] private float waitToSpawn = 1.0f;
    private GameObject lastSpawnedGameObject = null;
    Range lastRange = new Range()
    {
        xMin = -5000,
        xMax = -4999
    };

    private struct Range
    {
        public float xMin;
        public float xMax;
        public readonly bool IsInside(float x)
        {
            return x > xMin && x < xMax;
        }

        public readonly float center { get { return (xMin + xMax) / 2; } }
    };

    private void Start()
    {
        obstacles = new GameObject[][] { obstaclesStage0, obstaclesStage1, obstaclesStage2, obstaclesStage3, obstaclesStage4 };
    }

    // Update is called once per frame
    private void Update()
    {
        if (!canSpawn) return;

        waitToSpawn -= Time.deltaTime;

        if (waitToSpawn > 0.0f) return;

        int currentLevel = GameManager.Instance.GetStage();
        Debug.Log("stage Spawner:" + currentLevel);

        int obstacleLen = obstacles[currentLevel].Length;

        GameObject obstacleGameObject = lastSpawnedGameObject;

        obstacleGameObject = obstacles[currentLevel][Random.Range(0, obstacleLen)];

        /*while (obstacleGameObject == lastSpawnedGameObject) {
            int randomObstacle = Random.Range(0, obstacleLen);
            Debug.Log(randomObstacle);
            obstacleGameObject = obstacles[currentLevel][randomObstacle];
        }*/

        GameObject obstacleSpawed = Instantiate(obstacleGameObject);

        BaseObstacle obstacle = obstacleSpawed.GetComponent<BaseObstacle>();
        BaseObstacle lastSpawned = null;

        const float characterPositionX = 0;
        float characterVelocityX = GameManager.Instance.playerVelocityX;
        float obstacleVelocityY = obstacle.GetSpeed();
        float obstacleSize = obstacle.GetSize();
        float lastSpawnedSize = 0;

        float leftMargin = Camera.main.transform.position.x - (Camera.main.orthographicSize * Camera.main.aspect) + obstacleSize;
        float rightMargin = Camera.main.transform.position.x + (Camera.main.orthographicSize * Camera.main.aspect) - obstacleSize;

        if (lastSpawnedGameObject != null)
        {
            lastSpawned = lastSpawnedGameObject.GetComponent<BaseObstacle>();
            lastSpawnedSize = lastSpawned.GetSize();
        }

        float secondToReach = (transform.position.x - characterPositionX) / obstacleVelocityY;
        float possibleDistance = characterVelocityX * secondToReach;
        Range impossibleRange = new()
        {
            xMin = Convert.ToInt32(possibleDistance <= obstacleSize) * (characterPositionX - obstacleSize),
            xMax = Convert.ToInt32(possibleDistance <= obstacleSize) * (characterPositionX + obstacleSize)
        };

        float random = Random.Range(leftMargin, rightMargin);

#if UNITY_EDITOR
        Debug.DrawLine(new Vector3(lastRange.xMin, transform.position.y, 0), new Vector3(lastRange.xMin, transform.position.y - 60, 0), new Color(1, 0, 0, 0.5f), 5);
        Debug.DrawLine(new Vector3(lastRange.xMax, transform.position.y, 0), new Vector3(lastRange.xMax, transform.position.y - 60, 0), new Color(1, 0, 0, 0.5f), 5);

        Debug.DrawLine(new Vector3(impossibleRange.xMin, transform.position.y, 0), new Vector3(impossibleRange.xMin, transform.position.y - 60, 0), new Color(1, 0, 0, 0.5f), 5);
        Debug.DrawLine(new Vector3(impossibleRange.xMax, transform.position.y, 0), new Vector3(impossibleRange.xMax, transform.position.y - 60, 0), new Color(1, 0, 0, 0.5f), 5);
#endif

        int maxInt = 1000;

        while ((lastRange.IsInside(random) || impossibleRange.IsInside(random)) && maxInt > 0) { random = Random.Range(leftMargin, rightMargin); --maxInt; }

        obstacleSpawed.transform.position = new Vector3(random, transform.position.y, 0);
        lastSpawnedGameObject = obstacleGameObject;

        lastRange = new()
        {
            xMin = obstacleSpawed.transform.position.x - lastSpawnedSize,
            xMax = obstacleSpawed.transform.position.x + lastSpawnedSize
        };

        waitToSpawn = 2;
    }


    public void enableSpawn() { canSpawn = true; }
    public void disableSpawn() { canSpawn = false; }
}