using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField]
    private float maxY = -10.0f;
    [SerializeField]
    private float speed = 3.0f;
    [SerializeField]
    private float startPositionY = 0.0f;

    [Header("In visualizzazione")]
    [SerializeField]
    private float currentPositionY;

    private void Start()
    {
        currentPositionY = startPositionY;
    }


    private void Update()
    {
        currentPositionY -= speed * Time.deltaTime;
        this.gameObject.transform.position = new Vector3(0, currentPositionY, 0);
        if (currentPositionY < maxY)
        {
            this.gameObject.transform.position = new Vector3(0, startPositionY, 0);
            currentPositionY = startPositionY;
        }
    }
}
