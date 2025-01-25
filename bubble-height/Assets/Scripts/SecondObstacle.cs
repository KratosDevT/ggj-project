using UnityEngine;
using UnityEngine.UIElements;

public class SecondObstacle : BaseObstacle
{
    private BoxCollider2D boxCollider;
    private float movement;

    [SerializeField]
    Transform[] waypoints;
    int waypoint_index = 0;
    void Start()
    {
        obstacleSpeed = speed * 0.5f; //it depends from the speed of the BaseObstacle
        boxCollider = GetComponent<BoxCollider2D>();
        movement = -obstacleSpeed * Time.deltaTime;
    }
    void Update()
    {
        Move();
    }
    protected override void  Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypoint_index].transform.position, movement);

        if(transform.position == waypoints[waypoint_index].transform.position)
        {
            ++ waypoint_index;
        }
        if(waypoint_index == waypoints.Length)
        {
            return;
        }
    }
    public override float getSize()
    {
        return boxCollider.size.x * transform.localScale.x;
    }
}