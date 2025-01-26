using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    [SerializeField]
    private float speed = 1.0f;
    private Vector3 pos;

    //Array that contains all the bubbles (Max 10 bubbles)
    private List<GameObject> bubbles = new List<GameObject>();
    private int numberOfBubbles = 10;
    private Vector3[] bubblePosition = new Vector3[10];   //.GetComponent<SphereCollider>().radius;
    private float radius = 0f;


    //Timer to manage the collisions
    private float timer = 0f;

    private float leftBound;
    private float rightBound;

    [SerializeField]
    private GameObject bubblePrefab;

    public float GetSpeed()
    {
        return speed;
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector3(0, transform.position.y, transform.position.z);

        radius = 2 * (GetComponent<CircleCollider2D>().radius);
        Debug.Log(radius);

        //Populate the bubbles array
        GenerateBubbles(numberOfBubbles);

        leftBound = Camera.main.transform.position.x - (Camera.main.orthographicSize * Camera.main.aspect) + 1.50f;
        rightBound = Camera.main.transform.position.x + (Camera.main.orthographicSize * Camera.main.aspect) - 1.50f;

    }

    private void Update()
    {
        if (timer > 0f)
            timer -= Time.deltaTime;
        float horizontalMovement = Input.GetAxis("Horizontal");
        //Character movement letf/right
        float x = transform.position.x + horizontalMovement * speed * Time.deltaTime;
        x = Mathf.Clamp(x, leftBound, rightBound);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);

        //transform.position = pos;
        transform.Rotate(0, 0, speed * Time.deltaTime);

    }

    //Physics2D.BoxCastAll -> Funzione pi� otimizzata che va in base al tempo che imposti tu
    private void OnCollisionEnter2D(Collision2D collision)
    {
        float radiusCollider = GetComponent<CircleCollider2D>().radius;

        //If the timer is still going on, ignore the collision
        if (timer > 0f)
            return;
        timer = 3;    //Invincible for timer time

        Debug.Log("Hit");

        GameObject bubble = bubbles[bubbles.Count - 1];

        bubbles.Remove(bubble);
        Destroy(bubble);

        radiusCollider -= 0.3f;
        GetComponent<CircleCollider2D>().radius = radiusCollider;

        //Return of the remaining HP
        GameManager.PlayerIsHit();
    }

    public void GenerateBubbles(int howManyBubbles)
    {
        //numberOfBubbles = howManyBubbles;


        float segment = (2 * Mathf.PI) / (howManyBubbles - 1);


        for (int i = 0; i < howManyBubbles; i++)
        {

            float angle = segment * (i - 1);

            float x = radius * Mathf.Cos(angle) * Convert.ToInt32(i != 0);
            float y = radius * Mathf.Sin(angle) * Convert.ToInt32(i != 0) + transform.position.y;

            //All sons of the parent gameObject CharacterMovement
            bubbles.Add(Instantiate(bubblePrefab, new Vector3(x, y, 0), Quaternion.identity, transform));

        }

        GetComponent<CircleCollider2D>().radius = 3;
    }


}
