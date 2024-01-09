using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameManagerScript gameManagerScript;
    Rigidbody rb;
    Transform tf;
    private Transform player;

    private bool isStan;
    public float coolTime;
    private float coolTimeBuff;

    private void EnemyAction()
    {
       StateCheck();
        LookPlayer();
    }
    private void StateCheck()
    {
        if (this.tag == "Stan")
        {
            if(rb.velocity.x < 1)
            {
                if(rb.velocity.z < 1)
                {
                    this.tag = "Enemy";
                    isStan = false;
                }
            }
        }
    }
    private void LookPlayer()
    {
        if (!isStan)
        {
            tf.rotation = new Quaternion(0, ToPlayer().y*2, 0, 1);
        }
    }
    private Vector2 ToPlayer()
    {
        Vector2 pos = new Vector2(player.position.x - tf.position.x, player.position.z - tf.position.z);
         pos.Normalize();
        return pos;
    }
    private void Attack()
    {
        if (!isStan)
        {

        }
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wave")
        {
            rb.velocity= new Vector3( other.GetComponent<Rigidbody>().velocity.x/2, 0, other.GetComponent<Rigidbody>().velocity.z/2);
            this.tag = "Stan";
            isStan=true;
        }
        if(other.tag == "Wave2")
        {
            rb.velocity = new Vector3(other.GetComponent<Rigidbody>().velocity.x / 1.75f, 0, other.GetComponent<Rigidbody>().velocity.z / 1.75f);
            this.tag = "Stan";
            isStan=true;
        }
        if (other.tag == "Wave3")
        {
            rb.velocity = new Vector3(other.GetComponent<Rigidbody>().velocity.x / 1.5f, 0, other.GetComponent<Rigidbody>().velocity.z / 1.5f);
            this.tag = "Stan";
            isStan=true;
        }
     
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Circle")
        {

            gameManagerScript.CircleSizeUp(new Vector2((float)Math.Sqrt(rb.velocity.x * rb.velocity.x + rb.velocity.z * rb.velocity.z)/2, (float)Math.Sqrt(rb.velocity.x * rb.velocity.x + rb.velocity.z * rb.velocity.z)/2));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tf=GetComponent<Transform>();   
        gameManagerScript = GameObject.FindWithTag("Manager").GetComponent<GameManagerScript>();
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();

        coolTimeBuff = coolTime * 60;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyAction();
    }
}
