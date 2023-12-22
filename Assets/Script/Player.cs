using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    Transform tf;
    private Transform cameraPos;
    public new GameObject camera;
    public GameObject wave;

    public float playerMoveAcce;
    public float playerMoveSpeedMax;
    private bool isCanAttack;
    private float cameraRotate;


    private void PlayerControll()
    {
        PlayerMove();
    }
    
    private void PlayerMove()
    {
        PlayerAddSpeed();
        Attack();
    }//移動関連
    private void PlayerAddSpeed()
    {
        if (Input.GetAxis("leftStickX") != 0 || Input.GetAxis("leftStickY") != 0)
        {
            rb.velocity = Vector3.zero;
            Vector2 stick = new Vector2(playerMoveAcce * Input.GetAxis("leftStickX"), -playerMoveAcce * Input.GetAxis("leftStickY"));
            Vector2 camera = CameraVectorTransform(stick);
            //rb.velocity = new Vector3(rb.velocity.x + stick.x, 0, rb.velocity.z +stick.y);
            rb.velocity = new Vector3(rb.velocity.x + camera.x, 0, rb.velocity.z + camera.y);
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
           //rb.velocity = new Vector3(rb.velocity.x + key.x, 0, rb.velocity.z + key.y);
            rb.velocity = new Vector3(rb.velocity.x + camera.x, 0, rb.velocity.z + camera.y);

        }
        else
        {
            rb.velocity = Vector3.zero;
        }
      
    }//プレイヤーに加速度を足す奴
    private Vector2 CameraVectorTransform(Vector2 move)
    {
        Vector2 vector;
        vector = Vector2.zero;
        vector = new Vector2(vector.x + move.x * camera.transform.right.x, vector.y + move.x * camera.transform.right.z);
        vector = new Vector2(vector.x + move.y * CameraForward().x, vector.y + move.y * CameraForward().y);
        return vector;
    }//カメラの向いてる方向にベクトル変換する奴
    private float ToRadian(float angle)
    {
        return angle * (float)Math.PI / 180f;
    }//radに変換する
    private Vector2 CameraForward()
    {
        Vector2 forward = Vector2.zero;
        forward = Vector2.Scale(new Vector2(camera.transform.forward.x, camera.transform.forward.z), new Vector2(1, 1).normalized);
        return forward;
    }//カメラの正面をだす奴


    private void Attack()
    {
        if (Input.GetAxis("leftTrigger") != 0)
        {
            CreateWave();
        }
        if(Input.GetAxis("leftTrigger")==0)
        {
            isCanAttack = true;
        }
    }
    private void CreateWave()
    {
        if (isCanAttack)
        {
            isCanAttack=false;
            UnityEngine.Object instans = Instantiate(wave, new Vector3(tf.position.x, tf.position.y, tf.position.z), new Quaternion(0, 0, 0, 0));
        }
    }
    private float ToDegree(float rad)
    {
        return rad * (float)(180f/Math.PI);
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tf = GetComponent<Transform>();
        cameraPos=GameObject.FindWithTag("MainCamera").GetComponent<Transform>();
        //camera = GetComponent<GameObject>();
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerControll();
        cameraRotate = cameraPos.localRotation.y;
     
    }
}
