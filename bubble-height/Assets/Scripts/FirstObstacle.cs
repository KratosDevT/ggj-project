using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class FirstObstacle : BaseObstacle
{

    private float movement;

    void Start()
    {
        obstacleSpeed = speed * 0.9f; //it depends from the speed of the BaseObstacle
    }

    void Update()
    {
        Move();
    }

    protected override void  Move()
    {
        movement = obstacleSpeed * Time.deltaTime;
        transform.Translate(0, -movement, 0);
    }

    public override float GetSize() //the difference between the center of the collider and the edge on the x-axis
    {
        return GetComponent<CircleCollider2D>().radius;
    }
}
