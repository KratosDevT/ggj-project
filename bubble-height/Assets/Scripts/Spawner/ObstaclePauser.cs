using System.Collections.Generic;
using UnityEngine;

public class ObstaclePauser : MonoBehaviour {

    private static List<GameObject> gameObjects = new List<GameObject>();

    private void OnCollisionEnter2D(Collision2D collision) {
        gameObjects.Add(collision.gameObject);
    }

    public static void PauseElemets() {
        foreach (GameObject obj in gameObjects) {
            obj.GetComponent<BaseObstacle>().enabled = false;
        }
    }

    public static void DestroyElemets() {
        foreach (GameObject obj in gameObjects) {
            Destroy(obj);
        }
    }

    public static void UpdateElemet(GameObject obj) {
        gameObjects.Remove(obj);
    }

}
