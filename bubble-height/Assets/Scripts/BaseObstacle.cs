using UnityEngine;

public abstract class BaseObstacle : MonoBehaviour
{
    [SerializeField]
    protected float speed = 2f;

    protected float obstacleSpeed; //specific speed of the specificObstacle
    protected abstract void Move();

    public abstract float getSize();

    public float getSpeed()
    {
        return obstacleSpeed;
    }
}

