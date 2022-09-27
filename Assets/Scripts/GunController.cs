using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    private int layerMask;
    public float maxLineLength = 50f;
    public Transform endOfBarrel;
    public GameObject hitParticle;
    public ScoreController scoreController;

    private void Start()
    {
        layerMask = 1 << 8;
    }


    public RaycastHit ShootGun()
    {
        scoreController.IncrementNumberOfShots();

        Vector3 fwd = -transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, fwd, out hit, maxLineLength, layerMask)) {
            if (hit.collider.gameObject.CompareTag("Target"))
            { 
                scoreController.AddToScore(1);
            }

            Instantiate(hitParticle, hit.point, Quaternion.identity);
        }


        return hit;
    }
}
