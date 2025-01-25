using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class FirstObstacle : BaseObstacle
{
    [SerializeField]
    private float speed = 2f;

    float y = 0f;
    void Update()
    {
        Move();
    }
    protected override void  Move()
    {
        y += speed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x, -y);
    }
    public float getSpeed()
    {
        return speed;
    }
}
