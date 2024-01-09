using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StrikeScript : MonoBehaviour
{
    Transform tf;
    Rigidbody rb;
    public float movePower;
    public float hpTime;
    // Start is called before the first frame update
    private void StrikeAction()
    {
        Move();
        CountDown();
    }
    private void Move()
    {
        rb.velocity = new Vector3( AcceRotate().x, 0,  AcceRotate().y);
    }
    private Vector2 AcceRotate()
    {
        Vector2 buffer;
        return buffer = new Vector2(movePower * (float)Math.Cos(ToRadian(-tf.localEulerAngles.y)), movePower * (float)Math.Sin(ToRadian(-tf.localEulerAngles.y)));
    }
    private float ToRadian(float angle)
    {
        return angle * (float)Math.PI / 180f;
    }
    private void CountDown()
    {
        hpTime--;
        if(hpTime < 0)
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        tf=GetComponent<Transform>();
        rb=GetComponent<Rigidbody>();
        hpTime *= 60;
    }

    // Update is called once per frame
    void Update()
    {
        StrikeAction();
    }
}
