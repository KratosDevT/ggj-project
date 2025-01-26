using UnityEngine;

public class FourthObstacle : SecondObstacle
{
    [SerializeField]
    private float xdelay = 4f;
    private float prevDirection;
    private float rotationDelay = 60f;
    private Vector3 rotation;

    void Start()
    {
        obstacleSpeed = speed * 1.5f; //it depends from the speed of the BaseObstacle
        nextPosition = transform.position;
        Quaternion rotation = transform.rotation;
        if(nextPosition.x > 0)
        {
            nextPosition.x += xdelay;
            direction = -1;
            Vector3 scale = transform.localScale;
            scale.z *= -1; // Flip the x-axis
            transform.localScale = scale;
            transform.rotation *= Quaternion.Euler(-rotationDelay, 0, 0);
        }
        else
        {
            nextPosition.x -= xdelay;
            direction = 1;
        }
        prevDirection = direction; //initialization of prevDirection
        horizontalLimit = (Camera.main.orthographicSize * Camera.main.aspect) + Camera.main.transform.position.x - 0.75f; //limit bounded to camera edges
    }
    void Update()
    {
        if(nextPosition.x >= horizontalLimit || nextPosition.x <= -horizontalLimit)
        {
            Move();
        }
        else
        {
            base.Move();
        }
        if ((direction != prevDirection))
        {
            Vector3 scale = transform.localScale;
            Quaternion rotation = transform.rotation;
            scale.z *= -1; // Flip the x-axis
            transform.localScale = scale;
            prevDirection = direction;
            transform.rotation *= Quaternion.Euler(direction == 1 ? rotationDelay : -rotationDelay, 0f, 0f);
        }
    }
    protected override void  Move()
    {
        movement = obstacleSpeed * Time.deltaTime;
        nextPosition.x += movement * direction * 2f; //changing the x axis for the double of the y axis
        nextPosition.y += -movement * 2f; //changing the y axis
        transform.position = Vector3.Lerp(transform.position, nextPosition, 0.5f);
    }
}
