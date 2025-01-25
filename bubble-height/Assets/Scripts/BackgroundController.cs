using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float maxY = 30f;
    public float speed = 0.2f;
    public float currentPositionY = 0.0f;
    // Update is called once per frame
    void Update()
    {
        currentPositionY += speed * Time.deltaTime;
        this.gameObject.transform.position = new Vector3(0, currentPositionY, 0);
        if (currentPositionY > maxY)
        {
            this.gameObject.transform.position = new Vector3(0, 0, 0);
            currentPositionY = 0;
        }
    }
}
