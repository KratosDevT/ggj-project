using UnityEngine;

public class DestructorController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
         Destroy(other.gameObject);
    }
}
