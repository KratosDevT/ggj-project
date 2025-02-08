using UnityEngine;
using UnityEngine.SceneManagement;


public class StartMenuController : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("start game");
        SceneManager.LoadScene(1);
    }
}
