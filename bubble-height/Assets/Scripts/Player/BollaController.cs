using UnityEngine;

public class BollaController : MonoBehaviour
{
    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponentInParent<CharacterController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("triggerEnter:" + other.gameObject.name);
        characterController.HandlePlayerHit(1, gameObject);
    }
}

