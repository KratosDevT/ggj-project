using UnityEngine;

public abstract class BaseObstacle : MonoBehaviour
{
    [SerializeField]
    protected float speed = 2f;
    protected virtual void Move(){}

    public virtual float getSpeed()
    {
        return speed;
    }
}

