using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {

    [SerializeField]
    private Dictionary<int, GameObject[]> obstacles = new Dictionary<int, GameObject[]>();
    private bool canSpawn;
    private float waitToSpawn;

    // Update is called once per frame
    void Update() {

        if(!canSpawn) return;

        waitToSpawn -= Time.deltaTime;

        if (waitToSpawn > 0.0f) return; 

        int currentLevel = 0;//todo: get level 

        int obstacleLen = obstacles[currentLevel].Length;

        int randomNumber = Random.Range(0, obstacleLen);

        GameObject spawnedObstacle = Instantiate(obstacles[currentLevel][randomNumber]);

        int randomPosition = Random.Range(0, 0); //left right x position limit

        spawnedObstacle.transform.position = new Vector3(randomPosition, transform.position.y, 0);
        
        int a = randomNumber; //todo: get the time difference from gamemanager 

    }
    
    public void enableSpawn() { canSpawn = true; }
    public void disableSpawn() { canSpawn = false; }

}
