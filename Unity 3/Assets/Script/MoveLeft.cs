using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private PlayerControlle playerControlle;
    public float speed;
    public float leftBound;

    // Start is called before the first frame update
    void Start()
    {
        playerControlle = FindObjectOfType<PlayerControlle>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerControlle.isGameover)
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (transform.position.x < leftBound&&gameObject.CompareTag("Obstacle"))
            Destroy(gameObject);
    }
}
