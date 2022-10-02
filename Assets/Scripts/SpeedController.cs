using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedController : MonoBehaviour
{
    public float speed = 0f;
    public float increaseSpeedBy = 1f;
    public float increaseSpeedInterval = 120f;
    public float maxSpeed = 15f;


    private void Start()
    {
        InvokeRepeating("IncreaseSpeed", increaseSpeedInterval, increaseSpeedInterval);
    }

    public void IncreaseSpeed()
    {
        if(speed < maxSpeed)
        {
            speed += increaseSpeedBy;
        }
    }

    // todo increase speed to max speed 
}