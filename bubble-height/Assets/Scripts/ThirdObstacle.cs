using UnityEngine;
using System;

public class ThirdObstacle : BaseObstacle
{
    private float movement;

    private float direction = 1; //module of direction

    private float horizontalLimit;

    void Start()
    {
        obstacleSpeed = speed * 1.1f; //it depends from the speed of the BaseObstacle
        movement = obstacleSpeed * Time.deltaTime;
        direction = Math.Sign(transform.position.x) * -1; //change based on the spawn position
        horizontalLimit = 2f;
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

    public override float GetSize() //the difference between the center of the collider and the edge on the x-axis
    {
        return GetComponent<CircleCollider2D>().radius;
    }
}