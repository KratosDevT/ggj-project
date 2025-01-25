using UnityEngine;

public class ThirdObstacle : BaseObstacle
{
    private float movement;

    private float frequency = 2f; // Frequenza dell'oscillazione
    private float amplitude = 0.5f; // Ampiezza dell'oscillazione
    private float verticalSpeedMultiplier = 0.5f; // Fattore per il movimento verso il basso

    private float timeElapsed = 0f; // Timer per l'oscillazione

    private Vector3 initialRotation = new Vector3(-110f, 0f, 0f); // Rotazione iniziale dell'asset
    private float maxTiltAngle = 15f; // Angolo massimo di inclinazione

    private float spawnPosition;

    void Start()
    {
        obstacleSpeed = speed * 0.8f; // Dipende dalla velocità della classe base
        transform.rotation = Quaternion.Euler(initialRotation); // Imposta la rotazione iniziale
        spawnPosition = transform.position.x;
    }

    void Update()
    {
        Move();
    }

    protected override void Move()
    {
        // Incrementa il tempo per calcolare l'oscillazione
        timeElapsed += Time.deltaTime;

        Vector3 nextPosition = transform.position;

        // Oscillazione sull'asse x
        nextPosition.x = Mathf.Sin(timeElapsed * frequency) * amplitude + spawnPosition;

        // Movimento verso il basso
        nextPosition.y -= obstacleSpeed * verticalSpeedMultiplier * Time.deltaTime;

        // Rotazione basata sulla distanza dal centro (limite orizzontale)
        float normalizedDistance = Mathf.Abs(nextPosition.x) / amplitude; // Valore normalizzato (0 al centro, 1 ai bordi)
        float tiltAngle = Mathf.Lerp(0f, maxTiltAngle, normalizedDistance); // Interpolazione per l'angolo

        // Inclinazione a destra o a sinistra in base alla posizione
        Vector3 currentRotation = initialRotation + new Vector3(0f, 0f, nextPosition.x > 0 ? -tiltAngle : tiltAngle);
        transform.rotation = Quaternion.Euler(currentRotation);

        // Aggiorna la posizione
        transform.position = Vector3.Lerp(transform.position, nextPosition, 0.4f);
    }

    public override float GetSize()
    {
        return GetComponent<CircleCollider2D>().radius;
    }
}
