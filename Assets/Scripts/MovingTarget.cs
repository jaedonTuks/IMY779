using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    public float maxMoveTo = 2.8f;
    public bool moveTarget = true;
    public SpeedController speedController;

    private void FixedUpdate()
    {
        if (moveTarget)
        {
            transform.Translate(new Vector3(0, 0, -speedController.speed * Time.deltaTime), Space.World);
            if (transform.position.z < maxMoveTo)
            {
                moveTarget = false;
            }
        }
    }
}
