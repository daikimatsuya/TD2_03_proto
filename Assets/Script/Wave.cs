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

    private void WaveAction()
    {
       
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
        player.ResetShotPower();
    }

    // Update is called once per frame
    void Update()
    {
        WaveAction();
    }
}
