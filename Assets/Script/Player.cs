using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
    public float cameraRotate;
    private float shotPower;
    private int powerLevel;
    private int mode;
    private int modeMax;

    private void PlayerControll()
    {
        PlayerMove();
        FollowCamera();
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
            isCanAttack = true;
            shotPower+=1;
        }
        if(Input.GetAxis("leftTrigger")==0)
        {
            if (shotPower < 30)
            {
                isCanAttack=false;
                shotPower = 0;
                powerLevel = 0;
            }
            if(shotPower <40) {
                powerLevel = 1;
            }
            if (shotPower < 50)
            {
                powerLevel = 2;
            }
            if (shotPower < 60)
            {
                powerLevel = 3;
            }
            CreateWave();
            SelectMode();
        }
    }
    private void CreateWave()
    {
        if (isCanAttack)
        {
            isCanAttack=false;
           
            UnityEngine.Object instans = Instantiate(wave, new Vector3(tf.position.x, tf.position.y, tf.position.z), new Quaternion(0, 0, 0, 0));
           // shotPower = 0;
        }
    }
    private void SelectMode()
    {
        if (Input.GetAxis("leftB") !=0)
        {
            if (mode < modeMax)
            {
                mode++;
            }
            
        }

        if (Input.GetAxis("rightB") != 0)
        {
            if (mode > 0)
            {
                mode--;
            }
        }

    }
    private float ToDegree(float rad)
    {
        return rad * (float)(180f/Math.PI);
    }
    public float GetShotpower()
    {
        return shotPower;
    }
    public int GetPowerLevel()
    {
        return powerLevel;
    }
    public void ResetShotPower()
    {
        shotPower = 0;
    }
    private void FollowCamera()
    {
        tf.localRotation = cameraPos.localRotation;
        tf.localEulerAngles = new Vector3(0, tf.localEulerAngles.y-90, 0);
    }
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

        rb = GetComponent<Rigidbody>();
        tf = GetComponent<Transform>();
        cameraPos=GameObject.FindWithTag("MainCamera").GetComponent<Transform>();

        mode = 2;
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerControll();
      
        cameraRotate = cameraPos.localEulerAngles.y;
     
    }
}
