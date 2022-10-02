using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetEndZoneController : MonoBehaviour
{

    public ScoreController scoreController;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Target"))
        {
            scoreController.MinusFromScore();
            Destroy(other.gameObject);
        }
    }
}
