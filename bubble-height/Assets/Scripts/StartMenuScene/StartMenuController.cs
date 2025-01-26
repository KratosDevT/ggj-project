using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    public void onClick() {
        SceneManager.LoadScene(1);
    }
}
