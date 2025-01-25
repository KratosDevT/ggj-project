using UnityEngine;

public class SecondObstacle : BaseObstacle
{
    void Start()
    {
        obstacleSpeed = speed * 0.5f; //it depends from the speed of the BaseObstacle
    }
    void Update()
    {
        Move();
    }
    protected override void  Move()
    {
        float movement = -obstacleSpeed * Time.deltaTime;
        transform.Translate(movement, movement * 0.5f, 0);
    }
    public override float getSize()
    {
        return 0f;
    }
}