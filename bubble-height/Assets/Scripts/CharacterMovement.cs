using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //private float horizontal;
    [SerializeField]
    private float speed = 1f;
    private Vector3 pos;

    private GameObject cameraObject; 
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   /* void Start()
    {
        
    }*/

    // Update is called once per frame
    void Update()
    {

        float horizontalMovement = Input.GetAxis("Horizontal");
        //Character movement letf/right
        pos.x = transform.position.x + horizontalMovement * speed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, -cameraObject.x, cameraObject.x);
        transform.position = pos;
        

    }

    
}
