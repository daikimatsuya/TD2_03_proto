using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Transform circle;
    public GameObject enemy;

    private bool isSumon;
    public  float sumonCount;
    private int sumonCountBuff;
    private Vector2[] sumonPos;
    public int enemyQuantity;

    private void BossAction()
    {
        Attack();
    }
    private void Attack()
    {
        SumonEnemy();
    }
    private void SumonEnemy()
    {
        if(Input.GetKeyDown(KeyCode.E)) 
        {
            isSumon = true;
            //for (int i = enemyQuantity; i >= 0;)
            //{
            //    sumonPos[i] = new Vector2(UnityEngine.Random.RandomRange(0, circle.localScale.x), UnityEngine.Random.RandomRange(0, circle.localScale.x));
            //    i--;
            //}
            sumonPos[0] = new Vector2(UnityEngine.Random.RandomRange(0, circle.localScale.x), UnityEngine.Random.RandomRange(0, circle.localScale.x));
        }
        if(isSumon)
        {
            sumonCountBuff--;
            if(sumonCountBuff < 0)
            {
                //for (int i = enemyQuantity; i >= 0;)
                //{
                //    UnityEngine.Object instans = Instantiate(enemy, new Vector3(sumonPos[i].x, 0, sumonPos[i].y), new Quaternion(0, 0, 0, 1));
                //    i--;
                //}
                UnityEngine.Object instans = Instantiate(enemy, new Vector3(sumonPos[0].x, 0, sumonPos[0].y), new Quaternion(0, 0, 0, 1));
                isSumon =false;

            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        circle = GameObject.FindWithTag("Circle").GetComponent<Transform>();
        sumonCountBuff = (int)(sumonCount * 60);

    }

    // Update is called once per frame
    void Update()
    {
        BossAction();
    }
}
