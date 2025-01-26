using UnityEngine;

public class FourthObstacle : SecondObstacle
{
    [SerializeField]
    private float xdelay = 10f;
    private Vector3 nextPosition;

    void Start()
    {
        obstacleSpeed = speed * 1.5f; //it depends from the speed of the BaseObstacle
        nextPosition = transform.position;
        if(nextPosition.x > 0)
        {
            nextPosition.x += xdelay;
            direction = -1;
        }
        else
        {
            nextPosition.x -= xdelay;
            direction = 1;
        }
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
    }
    protected override void  Move()
    {
        movement = obstacleSpeed * Time.deltaTime;
        nextPosition.x += movement * direction * 4f; //changing the x axis for the double of the y axis
        nextPosition.y += -movement; //changing the y axis
        transform.position = Vector3.Lerp(transform.position, nextPosition, 0.5f);
    }
}
