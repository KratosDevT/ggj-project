using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class FirstObstacle : BaseObstacle
{
    private CircleCollider2D circleCollider; //circle collider of FirstObstacle
    private float movement;

    void Start()
    {
        obstacleSpeed = speed * 1.5f; //it depends from the speed of the BaseObstacle
        circleCollider = GetComponent<CircleCollider2D>();
        movement = obstacleSpeed * Time.deltaTime;
    }

    void Update()
    {
        Move();
    }

    protected override void  Move()
    {
        transform.Translate(0, -movement, 0);
    }

    public override float GetSize() //the difference between the center of the collider and the edge on the x-axis
    {
        return circleCollider.radius;
    }
}
