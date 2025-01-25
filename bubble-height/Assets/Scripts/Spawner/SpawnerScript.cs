using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.TextCore.Text;
using Color = UnityEngine.Color;
using Random = UnityEngine.Random;

public class SpawnerScript : MonoBehaviour {

    [SerializeField] private GameObject[] obstaclesEasy;
    private GameObject[][] obstacles;
    [SerializeField] private bool canSpawn;
    private float waitToSpawn = 0.0f;
    private GameObject lastSpawnedGameObject = null;
    Range lastRange = new Range() {
        xMin = -5000,
        xMax = -4999
    };



    private struct Range {
        public float xMin;
        public float xMax;
        public readonly bool IsInside(float x) {
            return x > xMin && x < xMax;
        }

        public readonly float center { get { return (xMin + xMax) / 2; } }
    };

    void Start() {
        obstacles = new GameObject[][] { obstaclesEasy };
    }

    // Update is called once per frame
    void Update() {

        if (!canSpawn) return;

        waitToSpawn -= Time.deltaTime;

        if (waitToSpawn > 0.0f) return;

        int currentLevel = 0;//todo: get level 

        int obstacleLen = obstacles[currentLevel].Length;

        GameObject obstacleGameObject = null;

        obstacleGameObject = obstacles[currentLevel][Random.Range(0, obstacleLen - 1)];
        /*
        while (obstacleGameObject == lastSpawnedGameObject) {
            obstacleGameObject = obstacles[currentLevel][Random.Range(0, obstacleLen - 1)];
        }*/

        GameObject obstacleSpawed = Instantiate(obstacleGameObject);

        BaseObstacle obstacle = obstacleSpawed.GetComponent<FirstObstacle>();
        BaseObstacle lastSpawned;

        const float characterPositionX = 1;
        const float characterVelocityX = 0.2f;
        const float obstacleVelocityY = 0.2f;
        const float obstacleSize = 0.3f;
        const float lastSpawnedSize = obstacleSize;

        float leftMargin = Camera.main.transform.position.x - (Camera.main.orthographicSize * Camera.main.aspect) + obstacleSize;
        float rightMargin = Camera.main.transform.position.x + (Camera.main.orthographicSize * Camera.main.aspect) - obstacleSize;

        if (lastSpawnedGameObject != null) {
            lastSpawned = lastSpawnedGameObject.GetComponent<BaseObstacle>();
        }

        float secondToReach = (transform.position.x - characterPositionX) / obstacleVelocityY;
        float possibleDistance = characterVelocityX * secondToReach;
        Range impossibleRange = new() {
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

        lastRange = new() {
            xMin = obstacleSpawed.transform.position.x - lastSpawnedSize,
            xMax = obstacleSpawed.transform.position.x + lastSpawnedSize
        };

        waitToSpawn = 5;
    }


    public void enableSpawn() { canSpawn = true; }
    public void disableSpawn() { canSpawn = false; }
}