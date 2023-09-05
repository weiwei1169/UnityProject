using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private PlayerControlle playerControlle;//获取控制器
    public GameObject obstaclePrefab;
    public Vector3 spawnPos = new Vector3(20, 0, 0);
    public float startDelay, repeatRate;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), startDelay, repeatRate);
        playerControlle = FindObjectOfType<PlayerControlle>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnObstacle()
    {
        if(!playerControlle.isGameover)
        Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
    }
}
