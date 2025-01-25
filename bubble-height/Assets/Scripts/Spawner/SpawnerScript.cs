using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {

    [SerializeField] private GameObject[] obstaclesEasy;
    private bool canSpawn = true;
    private float waitToSpawn = 0.0f;

    // Update is called once per frame
    void Update() {

        if(!canSpawn) return;

        waitToSpawn -= Time.deltaTime;

        if (waitToSpawn > 0.0f) return; 

        int currentLevel = 0;//todo: get level 

        int obstacleLen = obstaclesEasy.Length;

        int randomNumber = Random.Range(0, obstacleLen);

        GameObject spawnedObstacle = Instantiate(obstaclesEasy[randomNumber]);

        int randomPosition = Random.Range(0, 0); //left right x position limit

        spawnedObstacle.transform.position = new Vector3(randomPosition, transform.position.y, 0);
        
        int a = randomNumber; //todo: get the time difference from gamemanager 

<<<<<<< HEAD
        float leftMargin = Camera.main.transform.position.x - Camera.main.orthographicSize + obstacleSize;
        float rightMargin = Camera.main.transform.position.x + Camera.main.orthographicSize - obstacleSize;

        if (lastSpawnedGameObject != null) {
            lastSpawned = lastSpawnedGameObject.GetComponent<BaseObstacle>();
        }

        float secondToReach = (transform.position.x - characterPositionX) / obstacleVelocityY;
        float possibleDistance = characterVelocityX * secondToReach;
        Range impossibleRange = new() {
            xMin = Convert.ToInt32(possibleDistance <= obstacleSize) * (characterPositionX - obstacleSize),
            xMax = Convert.ToInt32(possibleDistance <= obstacleSize) * (characterPositionX + obstacleSize)
        };

        Debug.Log("Ciao");

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
=======
>>>>>>> parent of cb66ef8 (Merge branch 'dev' of https://github.com/KratosDevT/ggj-project into dev)
    }
    
    public void enableSpawn() { canSpawn = true; }
    public void disableSpawn() { canSpawn = false; }

}
