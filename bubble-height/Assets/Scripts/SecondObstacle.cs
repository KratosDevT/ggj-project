using System;
using UnityEngine;
using UnityEngine.UIElements;

public class SecondObstacle : BaseObstacle
{
    private CircleCollider2D circleCollider;
    private float movement;
    private float direction = 1; //module of direction

    private float horizontalLimit = 10f; //temporary value of the camera border

    void Start()
    {
        obstacleSpeed = speed * 0.25f; //it depends from the speed of the BaseObstacle
        circleCollider = GetComponent<CircleCollider2D>();
        movement = obstacleSpeed * Time.deltaTime;
        direction = Math.Sign(transform.position.x) * -1; //change based on the spawn position
    }
    void Update()
    {
        Move();
    }
    protected override void  Move()
    {
        Vector3 nextPosition = transform.position;
        nextPosition.x += movement * direction * 2; //changing the x axis for the double of the y axis
        nextPosition.y += -movement; //changing the y axis
        if(nextPosition.x > horizontalLimit || nextPosition.x < -horizontalLimit) //changing the direction based on the spawner position
        {
            direction *= -1;
        }
        transform.position = Vector3.Lerp(transform.position, nextPosition, 0.5f);
    }

    public override float GetSize()
    {
        return circleCollider.radius;
    }
}