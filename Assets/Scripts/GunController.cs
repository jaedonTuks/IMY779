using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    private int layerMask;
    public float maxLineLength = 50f;
    public Transform endOfBarrel;
    public GameObject hitParticle;

    private void Start()
    {
        layerMask = 1 << 8;
    }


    public RaycastHit shootGun()
    {
        Vector3 fwd = -transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        Debug.DrawRay(transform.position, fwd * maxLineLength, Color.red);
        if (Physics.Raycast(transform.position, fwd, out hit, maxLineLength, layerMask)) {
           Instantiate(hitParticle, hit.point, Quaternion.identity);
        }


        return hit;
    }
}
