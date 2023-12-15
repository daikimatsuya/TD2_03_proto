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
            Vector2 camera = new Vector2(stick.x * (float)Math.Sin(cameraPos.rotation.y) + stick.y * (float)Math.Sin(cameraPos.rotation.y), stick.x * (float)Math.Cos(cameraPos.rotation.y) + stick.y * (float)Math.Cos(cameraPos.rotation.y));

            rb.velocity = new Vector3(rb.velocity.x + camera.y, 0, rb.velocity.z + camera.x);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
      
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
