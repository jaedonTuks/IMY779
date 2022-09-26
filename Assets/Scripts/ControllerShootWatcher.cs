using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerShootWatcher : MonoBehaviour
{

    private OVRInput.Button handTrigger;

    public bool canShoot = true;
    public float shootFrequency = 1.0f;
    public float shootAmplitude = 1.0f;
    public float duration = 1.0f;
    public GunController gunController;

    void Start()
    {
        handTrigger = OVRInput.Button.SecondaryIndexTrigger;
    }

    void FixedUpdate()
    {
        bool triggerDown = OVRInput.GetDown(handTrigger);
        
        // if trigger is still down from earlier
        if(!triggerDown) {
            canShoot = true;
        } else if (canShoot) {
            // if gun and trigger are still down
            shootGun();
        }
    }

    private void shootGun()
    {
        canShoot = false;
        gunShootVibration();
        RaycastHit hit = gunController.ShootGun();
        if (hit.collider)
        {
            Debug.Log("Gun shot hit: " + hit.collider.gameObject.name);
        } else
        {
            Debug.Log("Miss");
        }
    }

    private void gunShootVibration()
    {
        OVRInput.SetControllerVibration(shootFrequency, shootAmplitude, OVRInput.Controller.RTouch);
        Invoke("stopHaptic", duration);
    }
    private void stopHaptic()
    {
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
    }
}
