using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    public float horizontalInput;
    public float xRange = 14f;
    public GameObject SandwichPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //horizontalInput = Input.GetAxis("Horizontal"); //横向移动1~-1 逐渐加速
        horizontalInput = Input.GetAxisRaw("Horizontal");//1 0 -1瞬间加速

        transform.Translate(Vector3.right * horizontalInput * speed*Time.deltaTime);
        if (transform.position.x > xRange)
            transform.position = new Vector3(xRange, 0, 0);
        if(transform.position.x < -xRange)
            transform.position = new Vector3(-xRange, 0, 0);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            //发射披萨
            Instantiate(SandwichPrefab, transform.position + new Vector3(0, (float)0.25, 0),SandwichPrefab.transform.rotation);
            
        }
    }
}
