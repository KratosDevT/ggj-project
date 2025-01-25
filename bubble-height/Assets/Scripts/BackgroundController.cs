using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField]
    private float maxY = -1000.0f;
    [SerializeField]
    private float speed = 1.0f;
    [SerializeField]
    private float startPositionY = 20.0f;

    [Header("In visualizzazione")]
    [SerializeField]
    private float currentPositionY;

    private float zPos;

    private void Start()
    {
        currentPositionY = startPositionY;
        zPos = this.gameObject.transform.position.z;

    }


    private void Update()
    {
        currentPositionY -= speed * Time.deltaTime;
        this.gameObject.transform.position = new Vector3(0, currentPositionY, zPos);
        if (currentPositionY < maxY)
        {
            this.gameObject.transform.position = new Vector3(0, startPositionY, zPos);
            currentPositionY = startPositionY;
        }
    }

    public void setSpeed(float speed) {
        this.speed = speed;
    }
}
