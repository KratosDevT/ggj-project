using UnityEngine;

public class ThirdObstacle : BaseObstacle
{
    private float movement;

    private float frequency = 2f; //oscillation frequency
    private float amplitude = 0.5f; //oscillation amplitude
    private float verticalSpeedMultiplier = 0.5f; //factor for downward movement
    private float timeElapsed = 0f; //oscillation timer

    private Vector3 initialRotation = new Vector3(-110f, 0f, 0f); //check of the initial rotation of the asset
    private float maxTiltAngle = 20f; //maximum angle of inclination

    private float spawnPosition;

    void Start()
    {
        obstacleSpeed = speed * 0.8f; //it depends on the speed of the base class
        transform.rotation = Quaternion.Euler(initialRotation); //set the initial rotation
        spawnPosition = transform.position.x;
    }

    void Update()
    {
        Move();
    }

    protected override void Move()
    {
        timeElapsed += Time.deltaTime; //increase the time to calculate the oscillation

        Vector3 nextPosition = transform.position;

        //oscillation on the x axis
        nextPosition.x = Mathf.Sin(timeElapsed * frequency) * amplitude + spawnPosition;

        //oscillation on the y axis
        nextPosition.y -= obstacleSpeed * verticalSpeedMultiplier * Time.deltaTime * 2f;

        //rotation based on distance from center (horizontal limit)
        float normalizedDistance = Mathf.Abs(nextPosition.x) / amplitude; //normalized value (0 at the center, 1 at the edges)
        float tiltAngle = Mathf.Lerp(0f, maxTiltAngle, normalizedDistance); //angle interpolation

        //right or left rotation depending on the position
        Vector3 currentRotation = initialRotation + new Vector3(0f, 0f, nextPosition.x > 0 ? -tiltAngle : tiltAngle);
        transform.rotation = Quaternion.Euler(currentRotation);

        transform.position = Vector3.Lerp(transform.position, nextPosition, 0.4f);
    }

    public override float GetSize()
    {
        return GetComponent<CircleCollider2D>().radius * transform.localScale.x;
        
    }
}
