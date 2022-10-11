using UnityEngine;

public class GunController : MonoBehaviour
{
    public float maxLineLength = 50f;
    public Transform endOfBarrel;
    public ScoreController scoreController;


    public AudioSource gunShot;

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


    public RaycastHit ShootGun(
        Vector3? position = null,
        Vector3? forward = null
    )
    {
        scoreController.IncrementNumberOfShots();

        Vector3 useForward = forward ?? transform.TransformDirection(Vector3.forward);
        Vector3 usePosition = position ?? transform.position;
       

        return ShootRay(usePosition, useForward);
    }


    private RaycastHit ShootRay(Vector3 position, Vector3 forward)
    {
        gunShot.Play();
        RaycastHit hit;
        Debug.DrawRay(position, forward * maxLineLength, Color.red);
        if (Physics.Raycast(position, forward, out hit, maxLineLength, layerMask))
        {
            if (hit.collider.gameObject.CompareTag("Target"))
            {
                scoreController.AddToScore(1);
                mainParticleModule.startColor = hitColor;
            }
            else
            {
                mainParticleModule.startColor = missColor;
            }
            Instantiate(hitParticle, hit.point, Quaternion.identity);
        }


        return hit;
    }
}
