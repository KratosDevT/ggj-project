using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //private float horizontal;
    [SerializeField]
    private float speed = 1.0f;
    private Vector3 pos;

    [SerializeField]
    private Camera cameraObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    /* void Start()
     {

     }*/

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        //Character movement letf/right
        pos.x = transform.position.x + horizontalMovement * speed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, -cameraObject.orthographicSize, cameraObject.orthographicSize);
        transform.position = pos;
    }
}
