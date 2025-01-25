using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //private float horizontal;
    [SerializeField]
    private float speed = 1f;

    Vector3 pos;

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
        pos.x = Mathf.Clamp(pos.x, -5f, 5f);
        transform.position = pos;
        

    }

    
}
