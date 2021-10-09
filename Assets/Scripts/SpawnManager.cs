using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(30, 0, 0);

    private float startDelay = 1.0f;
    private float repeatDelay = 1.5f;

    private PlayerController playerControllerScript;

    void Start()
    {
        InvokeRepeating("SpawnObstacles", startDelay, repeatDelay);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        
    }

    private void SpawnObstacles()
    {
        if (playerControllerScript.GetGameOver() == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
