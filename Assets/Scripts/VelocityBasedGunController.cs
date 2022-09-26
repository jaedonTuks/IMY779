using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityBasedGunController : MonoBehaviour
{
    [Header("Velocity Settings")]
    public Vector3 worldVelocity;
    public Vector3 localVelocity;

    public Vector3 prevPosition;

    [Header("Gun settings")]
    public float movementThreshold = -0.03f;
    public GunController gunController;

    public int inFramesBetweenShot = 30;

    public int framesSinceLastShot = -1;


    private void Start()
    {
        prevPosition = transform.position;
    }

    void FixedUpdate()
    {
        worldVelocity = (transform.position - prevPosition) / (Time.deltaTime * inFramesBetweenShot);
        localVelocity = transform.InverseTransformDirection(worldVelocity);
        prevPosition = transform.position;

        checkAndTriggerGunShot();
    }

    private void checkAndTriggerGunShot()
    {
        if(framesSinceLastShot == -1 && localVelocity.z < movementThreshold)
        {
            Debug.Log("Movement triggered shot");
            gunController.ShootGun();
            framesSinceLastShot = 0;
        }

        if(framesSinceLastShot > inFramesBetweenShot)
        {
            framesSinceLastShot = -1;
        } else if (framesSinceLastShot != -1)
        {
            framesSinceLastShot++;
        }
        
    }
}
