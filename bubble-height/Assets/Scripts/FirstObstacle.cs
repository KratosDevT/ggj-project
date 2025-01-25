using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class FirstObstacle : BaseObstacle
{
    private float y = 0f;

    private float firstObstaclespeed;
    
    void Start()
    {
        firstObstaclespeed = base.getSpeed();
    }
    void Update()
    {
        Move();
    }
    protected override void  Move()
    {
        y += firstObstaclespeed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x, -y);
    }
    public override float getSpeed()
    {
        return firstObstaclespeed;
    }
}
