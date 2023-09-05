using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public int index;
    public float xRange;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnAnimal), 2f, 2f);
        //调用SpawnAnimal方法，在两秒后第一次调用，随后每两秒调用一次
        //SpawnAnimal();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnAnimal()
    {
        
        float xPos = Random.Range(-xRange, xRange);//随机的坐标
        index = Random.Range(0, animalPrefabs.Length);//随机数
        Instantiate(animalPrefabs[index], new Vector3(xPos, 0f, 19f), animalPrefabs[index].transform.rotation);
    }
}
