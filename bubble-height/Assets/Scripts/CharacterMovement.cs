using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //private float horizontal;
    [SerializeField]
    private float speed = 1.0f;
    private Vector3 pos;

    [SerializeField]
    private Camera cameraObject;

    private void Start()
    {
        Debug.Log(cameraObject);

    }
    void Update()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        //Character movement letf/right
        pos.x = transform.position.x + horizontalMovement * speed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, -2.5f, 2.5f);
        transform.position = pos;
    }
}
