using UnityEngine;

public class DestructorController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("destroy:" + other.gameObject.name);
        Destroy(other.gameObject);
    }
}
