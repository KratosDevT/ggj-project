using System;
using UnityEngine;
using UnityEngine.UIElements;

public class SecondObstacle : BaseObstacle
{
    protected float direction = 1; //module of direction

    protected float horizontalLimit;

    protected float movement;

    void Start()
    {
        obstacleSpeed = speed * 1.5f; //it depends from the speed of the BaseObstacle
        direction = Math.Sign(transform.position.x) * -1; //change based on the spawn position
        horizontalLimit = (Camera.main.orthographicSize * Camera.main.aspect) + Camera.main.transform.position.x - 0.75f; //limit bounded to camera edges
    }
    void Update()
    {
        Move();
    }
    protected override void  Move()
    {
        Vector3 nextPosition = transform.position;
        movement = obstacleSpeed * Time.deltaTime;
        nextPosition.x += movement * direction * 2f; //changing the x axis for the double of the y axis
        nextPosition.y += -movement * 2f; //changing the y axis
        if(nextPosition.x > horizontalLimit || nextPosition.x < -horizontalLimit) //changing the direction based on the spawner position
        {
            direction *= -1;
        }
        transform.position = Vector3.Lerp(transform.position, nextPosition, 0.5f);
    }

    public override float GetSize()
    {
        return GetComponent<CircleCollider2D>().radius;
    }
}