using UnityEngine;

public class DestructorController : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {

        ObstaclePauser.UpdateElemet(other.gameObject);
        Destroy(other.gameObject);
    }
}
