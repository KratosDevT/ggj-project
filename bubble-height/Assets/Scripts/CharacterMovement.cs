using System;
using System.ComponentModel;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    [SerializeField]
    private float speed = 1.0f;
    private Vector3 pos;
    private int hp;

    //Array that contains all the bubbles (Max 10 bubbles)
    private GameObject[] bubbles = new GameObject [10];
    private int numberOfBubbles = 10;
    private Vector3[] bubblePosition = new Vector3[10];   //.GetComponent<SphereCollider>().radius;
    private float radius = 0f;


    //Timer to manage the collisions
    private float timer = 0f;

    [SerializeField]
    private float leftBound = -2.0f;
    [SerializeField]
    private float rightBound = 2.0f;

    [SerializeField]
    private GameObject bubblePrefab;

    public float GetSpeed()
    {
        return speed;
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pos = new Vector3(0, transform.position.y, transform.position.z);

        radius = 2*(GetComponent<CircleCollider2D>().radius);
        Debug.Log(radius);

        //Populate the bubbles array
        GenerateBubbles(numberOfBubbles);
        
    }

    private void Update()
    {
        if (timer > 0f)
            timer -= Time.deltaTime;
        float horizontalMovement = Input.GetAxis("Horizontal");
        //Character movement letf/right
        pos.x = transform.position.x + horizontalMovement * speed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, leftBound, rightBound);
        transform.position = pos;
        transform.Rotate(0, 0 , 10 * Time.deltaTime);

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

    private GameObject[] GenerateBubbles(int howManyBubbles)
    {
        numberOfBubbles = howManyBubbles;


        float segment = (2 * Mathf.PI) / (howManyBubbles-1);

        //defineCoordinates();

        for (int i = 0; i < howManyBubbles; i++)
        {

            float angle = segment * (i - 1);

            float x = radius * Mathf.Cos(angle) * Convert.ToInt32(i!= 0);
            float y = radius * Mathf.Sin(angle) * Convert.ToInt32(i != 0) ;

            //All sons of the parent gameObject CharacterMovement
            bubbles[i] = Instantiate(bubblePrefab, new Vector3(x, y, 0), Quaternion.identity, transform);

        }


        GetComponent<CircleCollider2D>().radius = 3;
        return bubbles;
    }

    //Function called from GenerateBubbles once created all the bubbles
    /*private void defineCoordinates()
    {
        float x = 0f;
        float y = 0f;
        float angle = 0f;

        bubblePosition[0] = new Vector3(0,0,0);

        float segment = 2 * Mathf.PI;
        
        for (int i = 1; i < numberOfBubbles; i++)
        {
            angle = 

            x = radius * Mathf.Cos(angle);
            y = radius * Mathf.Sin(angle);

            bubblePosition[i] = new Vector3(x, y, 0);
        }
    
    }*/

}
