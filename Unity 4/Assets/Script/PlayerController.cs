using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;//获取刚体
    private GameObject focalPoint;

    public float speed;//小球移动速度
    public bool isFireUp;

    public float fireStrength;//火焰buff的力度
    public float waitTime = 7f;//buff的持续时间
    public GameObject fireRing;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");

    }

    // Update is called once per frame
    void Update()
    {
        float VerticalInput = Input.GetAxis("Vertical");//纵向力
        float horizontalInput = Input.GetAxis("Horizontal");//横向力
        rb.AddForce( focalPoint.transform.forward*VerticalInput * speed);
        rb.AddForce(focalPoint.transform.right*horizontalInput * speed);

        fireRing.SetActive(isFireUp);//判断光环是否生效
        if (isFireUp)
        {
            fireRing.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FireUp"))
        {
            isFireUp = true;
            Destroy(other.gameObject);
            StartCoroutine(FireUpCountDown());
        }
    }

    IEnumerator FireUpCountDown()
    {
        yield return new WaitForSeconds(waitTime);
        isFireUp = false;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enermy") && isFireUp)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 dirFromPlayer = collision.transform.position - transform.position;

            enemyRb.AddForce(dirFromPlayer * fireStrength,ForceMode.Impulse);

        }
    }
}
