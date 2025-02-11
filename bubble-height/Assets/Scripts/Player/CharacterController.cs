using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    [SerializeField] private float speed = 1.0f;
    private int hp;
    [SerializeField] private float leftBound;
    [SerializeField] private float rightBound;
    [SerializeField] private float distanceFromCenter = 1.5f;
    [SerializeField] private GameObject bubblePrefab;
    private List<GameObject> bubbles = new List<GameObject>();

    [SerializeField] float invincibleTimeInSeconds = 2f;
    [SerializeField] private bool isInvulnerable = false;


    private void Awake()
    {
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
        float horizontalMovement = Input.GetAxis("Horizontal");
        float x = transform.position.x + horizontalMovement * speed * Time.deltaTime;
        x = Mathf.Clamp(x, leftBound, rightBound);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
        transform.Rotate(0, 0, speed * Time.deltaTime);
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
            float x = transform.position.x + distanceFromCenter * Mathf.Cos(angle);
            float y = transform.position.y + distanceFromCenter * Mathf.Sin(angle);
            bubbles.Add(Instantiate(bubblePrefab, new Vector3(x, y, transform.position.z), Quaternion.identity, transform));
        }
    }
    public void HandlePlayerHit(int damage, GameObject gameObject)
    {
        if (isInvulnerable) return;
        TakeDamage(damage);
        StartCoroutine(PeaceTimeCoroutine());
        Destroy(gameObject);
    }
    private void TakeDamage(int damage)
    {
        GameManager.Instance.DamagePlayer(damage);
    }

    public void SetHp(int playerCurrentLife)
    {
        hp = playerCurrentLife;
    }

    public float GetSpeed()
    {
        return speed;
    }
    private IEnumerator PeaceTimeCoroutine()
    {
        isInvulnerable = true;
        yield return new WaitForSeconds(invincibleTimeInSeconds);
        isInvulnerable = false;
    }
}
