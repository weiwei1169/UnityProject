using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject player;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //player = GameObject.FindWithTag("Player");
        player = FindObjectOfType<PlayerController>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerDir = (player.transform.position - transform.position).normalized;
        rb.AddForce(playerDir * speed);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
