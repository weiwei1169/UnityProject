using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;//敌人预制体
    public GameObject fireUpPrefab;//火焰BUFF预制体

    public float spawnRange;//随机生成范围

    public int enermyCount;//敌人数量

    public int waveNumber = 1;

    //private Vector3 randomPos;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        enermyCount = FindObjectsOfType<Enermy>().Length;
        if(enermyCount == 0)
        {
            SpawnEnermy(waveNumber);
            waveNumber++;
            Instantiate(fireUpPrefab, RandomPos()+new Vector3(0,0.5f,0), fireUpPrefab.transform.rotation);
        }

    }

    public Vector3 RandomPos()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }

    void SpawnEnermy(int wave)
    {
        for (int i = 0; i < wave; i++)
        {
            //RandomPos();
            Instantiate(enemyPrefab, RandomPos(), Quaternion.identity);
        }
    }
}
