using UnityEngine;

public class BollaController : MonoBehaviour
{
    private CharacterController characterManager;

    private void Start()
    {
        characterManager = GetComponentInParent<CharacterController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision:" + other.gameObject.name);
        characterManager.HandlePlayerHit(1, gameObject);
    }
}

