using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //private float horizontal;
    [SerializeField]
    private float speed = 1.0f;
    private Vector3 pos;
    private int hp; 

    private float timer = 0f;

    //Usefull to diable the physhics of the character once hitted
    private Rigidbody rigidBodyCharacter;

    [SerializeField]
    private float leftBound = -2.0f;
    [SerializeField]
    private float rightBound = 2.0f;

    public float GetSpeed()
    {
        return speed;
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pos = new Vector3(0, transform.position.y, transform.position.z);
    }

    private void Update()
    {
        //Timer, wich goes one with each update
        if (timer > 0f)
            timer -= Time.deltaTime;
        float horizontalMovement = Input.GetAxis("Horizontal");
        //Character movement letf/right
        pos.x = transform.position.x + horizontalMovement * speed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, leftBound, rightBound);
        transform.position = pos;
       
    }
    //Physics2D.BoxCastAll -> Funzione più otimizzata che va in base al tempo che imposti tu
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If the timer is still going on, ignore the collision
        if (timer > 0f) 
            return;
        //Proceed with the actions caused by the collison
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Hit");
            //Return of the remaining HP
            hp = GameManager.PlayerIsHit();
            
        }
          
    }
}
