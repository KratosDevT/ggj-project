using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //private float horizontal;
    [SerializeField]
    private float speed = 1.0f;
    private Vector3 pos;

    [SerializeField]
    private float leftBound = -2.0f;
    [SerializeField]
    private float rightBound = 2.0f;

    //private GameObject cameraObject; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pos = new Vector3(0, transform.position.y, transform.position.z);
    }

    private void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        //Character movement letf/right
        pos.x = transform.position.x + horizontalMovement * speed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, leftBound, rightBound);
        transform.position = pos;
    }
}
