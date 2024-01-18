using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Boss boss;
    GameManagerScript gameManagerScript;
    Rigidbody rb;
    Transform tf;
    private Transform player;

    private bool isStan;
    public float coolTime;
    private float coolTimeBuff;
    private int power;
    public float damage;
    public float bouncePower;

    private void EnemyAction()
    {
       StateCheck();
        LookPlayer();
    }
    private void StateCheck()
    {
        if (this.tag == "Stan")
        {
            if(rb.velocity.x == 0f)
            {
                if(rb.velocity.z == 0f)
                {
                    //Destroy(this.gameObject);
                    //this.tag = "Enemy";
                    //isStan = false;
                }
            }
        }
    }
    private void LookPlayer()
    {
        tf.LookAt(player);
    }

    private void PlusSpeed(Vector3 speed)
    {
        rb.velocity = new Vector3(rb.velocity.x + speed.x, rb.velocity.y, rb.velocity.z + speed.z);
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
        //if (collision.gameObject.tag == "Circle")
        //{
        //    power++;
        //    // gameManagerScript.CircleSizeUp(new Vector2((float)Math.Sqrt(rb.velocity.x * rb.velocity.x + rb.velocity.z * rb.velocity.z)/8, (float)Math.Sqrt(rb.velocity.x * rb.velocity.x + rb.velocity.z * rb.velocity.z)/8));
        //}
        if(collision.gameObject.tag == "Wall")
        {
            Transform walltf = collision.gameObject.GetComponent<Transform>();
            rb.velocity = new Vector3(bouncePower * (float)Math.Sin(ToRadian(walltf.eulerAngles.y)), 0, bouncePower * (float)Math.Cos(ToRadian(walltf.eulerAngles.y)));
            power++;
        }
        if(collision.gameObject.tag == "Stan")
        {
            Rigidbody rigidbody;
            rigidbody=collision.gameObject.GetComponent<Rigidbody>();
            PlusSpeed(rigidbody.velocity);
        }
        if (collision.gameObject.tag == "Boss")
        {
            boss.Damage((damage * power));
          
        }
    }
    private float ToRadian(float angle)
    {
        return angle * (float)Math.PI / 180f;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tf=GetComponent<Transform>();   
        boss = GameObject.FindWithTag("Boss").GetComponent<Boss>();
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
