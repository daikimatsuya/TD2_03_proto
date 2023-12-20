using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    private Transform cameraPos;

    public float playerMoveAcce;
    public float playerMoveSpeedMax;

    private void PlayerControll()
    {
        PlayerMove();
    }
    private void PlayerMove()
    {
        PlayerAddSpeed();
    }
    private void PlayerAddSpeed()
    {
        if (Input.GetAxis("leftStickX") != 0 || Input.GetAxis("leftStickY") != 0)
        {
            rb.velocity = Vector3.zero;
            Vector2 stick = new Vector2(playerMoveAcce * Input.GetAxis("leftStickX"), -playerMoveAcce * Input.GetAxis("leftStickY"));
            Vector2 camera = CameraVectorTransform(stick);

            rb.velocity = new Vector3(rb.velocity.x + camera.y, 0, rb.velocity.z + camera.x);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.S))
        {
            rb.velocity=Vector3.zero;
            float rad=0;
            {
               
                if (Input.GetKey(KeyCode.D))
                {
                    rad = 0;
                }
                if (Input.GetKey(KeyCode.A))
                {
                    rad=180;
                }
                if (Input.GetKey(KeyCode.W))
                {
                    rad=90;
                }
                if (Input.GetKey(KeyCode.S))
                {
                    rad = -90;
                }
                if(Input.GetKey(KeyCode.D)&& Input.GetKey(KeyCode.W))
                {
                    rad = 45;
                }
                if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
                {
                    rad= -45;
                }
                if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
                {
                    rad = 135;
                }
                if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
                {
                   rad= -135;
                }
            }
            Vector2 key = new Vector2(playerMoveAcce * (float)Math.Cos(ToRadian(rad)), playerMoveAcce * (float)Math.Sin(ToRadian(rad)));
            Vector2 camera = CameraVectorTransform(key);
            rb.velocity = new Vector3(rb.velocity.x + key.x, 0, rb.velocity.z + key.y);
            //rb.velocity = new Vector3(rb.velocity.x + camera.x, 0, rb.velocity.z + camera.y);

        }
        else
        {
            rb.velocity = Vector3.zero;
        }
      
    }
    private Vector2 CameraVectorTransform(Vector2 move)
    {
        Vector2 vector;
        vector = Vector2.zero;
        vector = new Vector2(move.x * (float)Math.Cos(cameraPos.rotation.y) + move.y * (float)Math.Sin(cameraPos.rotation.y), move.x * (float)Math.Sin(cameraPos.rotation.y) + move.y * (float)Math.Cos(cameraPos.rotation.y));
        return vector;
    }
    public float ToRadian(float angle)
    {
        return angle * (float)Math.PI / 180f;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cameraPos=GameObject.FindWithTag("MainCamera").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerControll();
    }
}
