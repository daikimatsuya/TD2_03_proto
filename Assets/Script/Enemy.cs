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
    public GameObject explode;

    private bool isStan;
    public float coolTime;
    private float coolTimeBuff;
    private int power;
    public float damage;
    public float bouncePower;
    public float stanTime;
    private bool isLook;
    private bool canShoot;

    private void EnemyAction()
    {
       StateCheck();
        LookPlayer();
    }
    private void StateCheck()
    {
        if (this.tag == "Stan")
        {
            isLook = false;
            stanTime--;
            if(stanTime < 0)
            {
                Explode();
            }
        }
    }
    private void LookPlayer()
    {
        if(isLook)
        {
            tf.LookAt(player);
        }        
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
    private void Explode()
    {
        _ = Instantiate(explode, new Vector3(tf.position.x, tf.position.y, tf.position.z), Quaternion.identity);
        Destroy(this.gameObject);
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wave")
        {
            if(canShoot)
            {
                rb.velocity = new Vector3(other.GetComponent<Rigidbody>().velocity.x / 2, 0, other.GetComponent<Rigidbody>().velocity.z / 2);
                this.tag = "Stan";
                isStan = true;
            }
            else
            {
                Explode();
            }
        }
        if(other.tag == "Wave2")
        {
            if (canShoot)
            {
                rb.velocity = new Vector3(other.GetComponent<Rigidbody>().velocity.x / 2, 0, other.GetComponent<Rigidbody>().velocity.z / 2);
                this.tag = "Stan";
                isStan = true;
            }
            else
            {
                Explode();
            }

        }
        if (other.tag == "Wave3")
        {
            if (canShoot)
            {
                rb.velocity = new Vector3(other.GetComponent<Rigidbody>().velocity.x / 2, 0, other.GetComponent<Rigidbody>().velocity.z / 2);
                this.tag = "Stan";
                isStan = true;
            }
            else
            {
                Explode();
            }
        }
     
    }
    public void OnCollisionEnter(Collision collision)
    {
      
        if(collision.gameObject.tag == "Wall")
        {
            if (this.tag == "Stan")
            {
                Transform walltf = collision.gameObject.GetComponent<Transform>();
                rb.velocity = new Vector3(bouncePower * (float)Math.Sin(ToRadian(walltf.eulerAngles.y)), 0, bouncePower * (float)Math.Cos(ToRadian(walltf.eulerAngles.y)));
                power = 2;
            }
   
        }
        if(collision.gameObject.tag == "Stan")
        {
            if (canShoot)
            {
                Rigidbody rigidbody;
                rigidbody = collision.gameObject.GetComponent<Rigidbody>();
                PlusSpeed(rigidbody.velocity);
                this.tag = "Stan";
            }
            else
            {
                Explode();
            }
       
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
        stanTime *= 60;
        isLook = true;
        if (boss.PopCount() < boss.GetEnemyCount() - 1) 
        {
            boss.PopUp();
            canShoot = false;
        }
        else
        {
            canShoot= true;
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        EnemyAction();
    }
}
