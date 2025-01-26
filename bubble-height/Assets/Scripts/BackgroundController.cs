using UnityEngine;

public class BackgroundController : MonoBehaviour
{

    [SerializeField] private float maxY = -1000.0f;
    [SerializeField] private float speedY = 1.0f;
    [SerializeField] private float speedX = 0.0f;
    [SerializeField] private float startPositionY = 20.0f;
    [SerializeField] private float startPositionX = 0.0f;

    [Header("In visualizzazione")]
    [SerializeField] private float currentPositionY;
    [SerializeField] private float currentPositionX;

    private float zPos;

    private void Start()
    {
        currentPositionY = startPositionY;
        currentPositionX = startPositionX;
        zPos = this.gameObject.transform.position.z;
    }


    private void Update()
    {
        currentPositionY -= speedY * Time.deltaTime;
        currentPositionX += speedX * Time.deltaTime;
        this.gameObject.transform.position = new Vector3(currentPositionX, currentPositionY, zPos);

        if (currentPositionY < maxY)
        {
            setBackgroundStartPosition();
        }
    }

    public void setSpeedY(float speed)
    {
        speedY = speed;
    }

    public float getCurrentHeight()
    {
        return currentPositionY;
    }

    public void setBackgroundStartPosition()
    {
        this.gameObject.transform.position = new Vector3(0, startPositionY, zPos);
        currentPositionY = startPositionY;
    }
}
