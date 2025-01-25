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

    }
    
    public void enableSpawn() { canSpawn = true; }
    public void disableSpawn() { canSpawn = false; }

}
