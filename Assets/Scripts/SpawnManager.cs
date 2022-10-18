using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    private Vector3 spawnPosition = new Vector3(25, 0, 0);
    private float startDelayInSec = 2f;
    private float repeatRateInSec = 2f;

    private void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelayInSec, repeatRateInSec);
    }

    private void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
    }

}
