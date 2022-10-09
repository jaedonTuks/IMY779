using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleBasedShootTrigger : MonoBehaviour
{
    [Header("Rotations")]
    public float updatePreviousPositionInterval = 0.3f;
    public float previousXRotation;
    public float currentXRotation;
    public float changeInXRotation;

    [Header("Gun settings")]
    public GunController gunController;
    public float minChangeToShootGun = 25f;
    public float maxChangeToShoot = 90f;
    public int inFramesBetweenShot = 30;
    public int framesSinceLastShot = -1;


    private Vector3 gunPrevPosition;
    private Vector3 gunPrevForward;
    // Start is called before the first frame update
    void Start()
    { 
        InvokeRepeating("UpdatePreviousForwardPosition", 0f, updatePreviousPositionInterval);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentXRotation = transform.localEulerAngles.x;
        changeInXRotation = previousXRotation - currentXRotation;

        CheckAndTriggerGunShot();
         
        previousXRotation = transform.localEulerAngles.x;
    }

    void UpdatePreviousForwardPosition()
    {
        if(!IsAngleChangeWithinBounds(changeInXRotation))
        {
            gunPrevPosition = gunController.transform.position;
            gunPrevForward = gunController.transform.TransformDirection(Vector3.forward);
        }
    }


    private void CheckAndTriggerGunShot()
    {
        float usingChange = changeInXRotation;
        Vector3 usingPosition = gunPrevPosition;
        Vector3 usingForward = gunPrevForward;
        if (framesSinceLastShot == -1 && IsAngleChangeWithinBounds(usingChange))
        {

            gunController.ShootGun(usingPosition, usingForward);
            framesSinceLastShot = 0;
        }

        if (framesSinceLastShot > inFramesBetweenShot)
        {
            framesSinceLastShot = -1;
            UpdatePreviousForwardPosition();
        }
        else if (framesSinceLastShot != -1)
        {
            framesSinceLastShot++;
        }

    }

    private bool IsAngleChangeWithinBounds(float angleChange)
    {
        return minChangeToShootGun < angleChange && angleChange < maxChangeToShoot;
    }

}
