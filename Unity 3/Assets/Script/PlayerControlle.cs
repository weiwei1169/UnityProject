using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlle : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim; //声明
    private AudioSource audioSource;

    public AudioClip crashClip, jumpClip;

    public ParticleSystem dirtParticle, explotionParticle;//两个粒子效果

    public float gravityModifier; //重力系数
    public float jumpForce;//跳跃系数

    public bool isGround;//跳跃状态默认值是false
    public bool isGameover;//游戏状态
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>(); //获取
        audioSource = GetComponent<AudioSource>();//获得音源
        Physics.gravity *= gravityModifier;//调整重力
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& isGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);//向上的力，瞬间的冲击力
            isGround = false;
            anim.SetTrigger("Jump_trig");
            dirtParticle.Stop();

            audioSource.PlayOneShot(jumpClip, 0.5f);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            dirtParticle.Play();
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            isGameover = true;
            //isGround = false;
            Debug.Log("GameOver!");
            anim.SetBool("Death_b", true);
            anim.SetInteger("DeathType_int", 1);
            explotionParticle.Play();
            dirtParticle.Stop();
            audioSource.PlayOneShot(crashClip, 0.5f);
        }
    }

}
