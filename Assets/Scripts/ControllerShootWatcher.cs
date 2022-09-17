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

    void Start()
    {
        handTrigger = OVRInput.Button.SecondaryIndexTrigger;
    }

    void Update()
    {
        bool triggerDown = OVRInput.GetDown(handTrigger);
        
        if(!triggerDown)
        {
            canShoot = true;
        } else if (canShoot)
        {
            canShoot = false;
            OVRInput.SetControllerVibration(shootFrequency, shootAmplitude, OVRInput.Controller.RTouch);
            Invoke("stopHaptic", duration);
            Debug.Log("Bang!");
        }
    }

    void stopHaptic()
    {
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
    }
}
