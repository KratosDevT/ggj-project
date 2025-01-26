using UnityEngine;

public class FifthObstacle : FirstObstacle
{
    private bool target = false;
    public float radius = 5f; // Raggio del movimento circolare
    public Vector3 center; // Centro del movimento circolare
    private float angle = 0f; // Angolo corrente in radianti
    void Start()
    {
        center = (transform.position.x, transform.position.y-radius, transform.position.z);
    }
    void Update()
    {
        if(Mathf.Abs(transform.position.y - 2) > 0.1f || target)
        {
            target = true;
            Move();
        }
        else
        {
            base.Move();
        }
    }
    protected override void  Move()
    {
        if(target)
        {
            // Aggiorna l'angolo in base alla velocità e al tempo
            angle += obstacleSpeed * Time.deltaTime;

            // Calcola le nuove coordinate usando la formula del cerchio
            float x = center.x + radius * Mathf.Cos(angle);
            float y = center.y + radius * Mathf.Sin(angle);

            // Imposta la nuova posizione dell'oggetto
            transform.position = new Vector3(x, y, transform.position.z);
        }
        else
        {
            base.Move();
        }
    }
}
