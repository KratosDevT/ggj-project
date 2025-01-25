using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class FirstObstacle : BaseObstacle
{
    private float firstObstaclespeed; //specific speed of the FirstObstacle

    void Start()
    {
        firstObstaclespeed = base.getSpeed() * 1.5f; //it depends from the speed of the BaseObstacle
    }
    void Update()
    {
        Move();
    }
    protected override void  Move()
    {
        float movement = -firstObstaclespeed * Time.deltaTime;
        transform.Translate(0, movement, 0);
    }
    public override float getSpeed()
    {
        return firstObstaclespeed;
    }
}
