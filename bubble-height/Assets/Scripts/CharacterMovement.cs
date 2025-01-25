using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //private float horizontal;
    [SerializeField]
    private float speed = 100f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
   /* void Start()
    {
        
    }*/

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal"); //GetAxisRaw to check

        transform.position = new Vector3(transform.position.x + horizontalMovement * speed * Time.deltaTime, 0, 0);
        
    }

    
}
