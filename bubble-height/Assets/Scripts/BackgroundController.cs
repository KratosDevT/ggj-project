using System;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private bool enableScrollXAxis = false;
    [SerializeField] private bool enableScrollYAxis = false;

    //[SerializeField] private float maxY = -1000.0f;

    [SerializeField] private float speedY = 0.0f;
    [SerializeField] private float speedX = 0.0f;
    [SerializeField] private float startPositionY = 0.0f;
    [SerializeField] private float startPositionX = 0.0f;

    [SerializeField] List<float> rangesToCheck = new List<float>();

    [Header("Coordinate In visualizzazione")]
    [SerializeField] private float currentPositionY;
    [SerializeField] private float currentPositionX;
    [SerializeField] private float currentPositionZ;

    private void Start()
    {
        currentPositionY = startPositionY;
        currentPositionX = startPositionX;
        currentPositionZ = transform.position.z;
        transform.position = new Vector3(currentPositionX, currentPositionY, currentPositionZ);
    }


    private void Update()
    {
        if (enableScrollYAxis)
        {
            currentPositionY += speedY * Time.deltaTime;
        }

        if (enableScrollXAxis)
        {
            currentPositionX += speedX * Time.deltaTime;
        }

        transform.position = new Vector3(currentPositionX, currentPositionY, currentPositionZ);
    }

    public void setSpeedY(float speed)
    {
        speedY = speed;
    }

    public void setBackgroundStartPosition()
    {
        transform.position = new Vector3(0, startPositionY, currentPositionZ);
        currentPositionY = startPositionY;
    }

    internal void activateScrollXAxis()
    {
        enableScrollXAxis = true;
    }

    internal float GetRangeForStage(int stage)
    {
        return rangesToCheck[stage];
    }
}
