using UnityEngine;

public class CloudActivator : MonoBehaviour
{
    private BackgroundController bgcontroller;
    private void Start()
    {
        bgcontroller = GetComponent<BackgroundController>();
    }

    void Update()
    {
        int stage = GameManager.getDifficulty();
        if (stage == 3)
        {
            bgcontroller.activateScrollXAxis();
        }
    }
}
