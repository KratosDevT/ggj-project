using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    [SerializeField] private float speed = 1.0f;
    [SerializeField] private int hp;
    [SerializeField] private float radius;
    [SerializeField] private float invincibleTimeInSeconds;
    [SerializeField] private float timer;
    [SerializeField] private float leftBound;
    [SerializeField] private float rightBound;
    [SerializeField] private GameObject bubblePrefab;
    private List<GameObject> bubbles = new List<GameObject>();


    private void Awake()
    {
        timer = invincibleTimeInSeconds;
        radius = 2.5f * (GetComponent<SphereCollider>().radius);
        transform.position = new Vector3(0, transform.position.y, transform.position.z);

        leftBound = Camera.main.transform.position.x - (Camera.main.orthographicSize * Camera.main.aspect) + 1.0f;
        rightBound = Camera.main.transform.position.x + (Camera.main.orthographicSize * Camera.main.aspect) - 1.0f;
    }


    void Start()
    {
        GenerateBubbles(hp);

    }

    private void Update()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
        }

        float horizontalMovement = Input.GetAxis("Horizontal");
        //Character movement letf/right
        float x = transform.position.x + horizontalMovement * speed * Time.deltaTime;
        x = Mathf.Clamp(x, leftBound, rightBound);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);

        transform.Rotate(0, 0, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        float radiusCollider = GetComponent<SphereCollider>().radius;

        //If the timer is still going on, ignore the collision
        if (timer > 0f)
        {
            return;
        }

        GameObject bubble = bubbles[bubbles.Count - 1];

        bubbles.Remove(bubble);
        Destroy(bubble);

        radiusCollider -= 0.3f;
        GetComponent<SphereCollider>().radius = radiusCollider;
        GameManager.Instance.DamagePlayer(1);
        timer = invincibleTimeInSeconds;
    }

    public void GenerateBubbles(int numberBubbles)
    {
        //firstBubble
        bubbles.Add(Instantiate(bubblePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity, transform));

        //bubbles > 1
        float segment = (2 * Mathf.PI) / (numberBubbles - 1);
        for (int i = 1; i < numberBubbles; i++)
        {
            float angle = segment * (i - 1);
            float x = transform.position.x + radius * Mathf.Cos(angle);
            float y = transform.position.y + radius * Mathf.Sin(angle);
            bubbles.Add(Instantiate(bubblePrefab, new Vector3(x, y, transform.position.z), Quaternion.identity, transform));
        }
        GetComponent<SphereCollider>().radius = numberBubbles;
    }

    public void SetHp(int playerCurrentLife)
    {
        hp = playerCurrentLife;
    }

    public float GetSpeed()
    {
        return speed;
    }
}
