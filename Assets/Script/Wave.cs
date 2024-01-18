using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Wave : MonoBehaviour
{
    new Transform transform;
    Rigidbody rb;
    private Transform playerPos;
    private Player player;

    private float shotPower;
    public float vector;
    public float sizeCut;
    private int level;
    private int mode;

    private void WaveAction()
    {
        SizeUp();
        Move();
        DestroyCount();
    }
    private void DestroyCount()
    {
        shotPower-=3;
        if( shotPower <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void LevelCheck()
    {
        if( level == 1 )
        {
            this.tag = "Wave";
        }
        if( level == 2 )
        {
            this.tag = "Wave2";
        }
        if ( level == 3)
        {
            this.tag = "Wave3";
        }

    }
    private void SizeUp()
    {
        if(mode == 1)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z + (mode - transform.localScale.x / 2) / (sizeCut+5));
        }
        if(mode == 2)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z + (mode - transform.localScale.x / 2) / sizeCut);
        }
        if(mode == 3)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z + (mode - transform.localScale.x / 2) / (sizeCut-3));
        }
        
    }
    private void Move()
    {
      
        rb.velocity = new Vector3(rb.velocity.x + vector * (float)Math.Cos(ToRadian(-transform.localEulerAngles.y)), 0, rb.velocity.z + vector * (float)Math.Sin(ToRadian(-transform.localEulerAngles.y)));
    }
    private float ToRadian(float angle)
    {
        return angle * (float)Math.PI / 180f;
    }
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        playerPos = GameObject.FindWithTag("Player").GetComponent<Transform>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();

        transform.rotation = playerPos.rotation;
        shotPower=player.GetShotpower();    
        level = player.GetPowerLevel();
        mode=player.GetMode();
        
       // LevelCheck();
        player.ResetShotPower();
    }

    // Update is called once per frame
    void Update()
    {
        WaveAction();
    }
}
