using UnityEngine;

public class GunController : MonoBehaviour
{
    public float maxLineLength = 50f;
    public Transform endOfBarrel;
    public ScoreController scoreController;


    public GameObject hitParticle;
    public ParticleSystem.MinMaxGradient hitColor;
    public ParticleSystem.MinMaxGradient missColor;

    private int layerMask;
    private ParticleSystem.MainModule mainParticleModule;

    private void Start()
    {
        layerMask = 1 << 8;
        mainParticleModule = hitParticle.GetComponent<ParticleSystem>().main;
    }


    public RaycastHit ShootGun()
    {
        scoreController.IncrementNumberOfShots();

        Vector3 fwd = -transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        Debug.DrawRay(transform.position, fwd * maxLineLength, Color.red);
        if (Physics.Raycast(transform.position, fwd, out hit, maxLineLength, layerMask)) {
            if (hit.collider.gameObject.CompareTag("Target"))
            { 
                scoreController.AddToScore(1);
                mainParticleModule.startColor = hitColor;
            } else
            {
                mainParticleModule.startColor = missColor;
            }
            Instantiate(hitParticle, hit.point, Quaternion.identity);
        }


        return hit;
    }
}
