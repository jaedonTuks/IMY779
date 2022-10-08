using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public Transform leftSpawnPoint;
    public Transform middleSpawnPoint;
    public Transform rightSpawnPoint;
    public GameObject targetPrefab;
    public Dictionary<SpawnPoint, Transform> spawnPointMap;

    private void Start()
    {
        spawnPointMap = new Dictionary<SpawnPoint, Transform>()
        {
            { SpawnPoint.Left, leftSpawnPoint },
            { SpawnPoint.Middle, middleSpawnPoint },
            { SpawnPoint.Right, rightSpawnPoint }
        };
    }

    public void SpawnNewTarget(SpawnPoint? spawn)
    {
        Transform spawnTransform = GetSpawnPointTransform(spawn);


        Debug.Log("Spawning new target");
        Instantiate(targetPrefab, spawnTransform.position, spawnTransform.rotation);
    }


    public Transform GetSpawnPointTransform(SpawnPoint? spawn)
    {
        Transform returnTransform;
        return spawnPointMap.TryGetValue(spawn ?? SpawnPoint.Middle , out returnTransform) ? returnTransform : middleSpawnPoint;
    }
}
