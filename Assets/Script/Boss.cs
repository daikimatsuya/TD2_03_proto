using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Transform tf;
    private Transform player;
    private Transform circle;
    public GameObject enemy;
    public GameObject strikeBlock;

    public float magnification;

    private bool isLook;
    private bool isSumon;
    private bool isStrike;
    private float strikeDeg;
    public  float sumonCount;
    private int sumonCountBuff;
    private Vector2[] sumonPos;
    public int enemyQuantity;
    private Vector2 tester;
    public float hp;
    private int enemyPop;

    private void BossAction()
    {
        Attack();
        LookPlayer();
    }
    private void Attack()
    {
        SumonEnemy();
        Strike();
    }
    private void LookPlayer()
    {
        if(isLook)
        {
            tf.LookAt(player);
        }        
    }
    private void SumonEnemy()
    {
        if(Input.GetKeyDown(KeyCode.E)) 
        {
            sumonPos = new Vector2[enemyQuantity];
            isSumon = true;
           enemyPop = 0;
            for (int i = 0; i < enemyQuantity;)
            {
#pragma warning disable CS0618 // 型またはメンバーが旧型式です
                sumonPos[i] = new Vector2(UnityEngine.Random.RandomRange(-circle.localScale.x, circle.localScale.x), UnityEngine.Random.RandomRange(-circle.localScale.x, circle.localScale.x));
#pragma warning restore CS0618 // 型またはメンバーが旧型式です

                i++;
            }
        }
        if(isSumon)
        {
            sumonCountBuff--;
            if(sumonCountBuff < 0)
            {
                for (int i = 0; i < enemyQuantity;)
                {
                    _ = Instantiate(enemy, new Vector3(sumonPos[i].x*magnification, 0, sumonPos[i].y*magnification), Quaternion.identity);
                    i++;
                }

                isSumon =false;

            }
        }
    }
    private void Strike()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            isStrike = true;
        }
        if(isStrike)
        {
            _ = Instantiate(strikeBlock, new Vector3(0, 0, 0), Quaternion.Euler(0, strikeDeg + 0, 0));
            _ = Instantiate(strikeBlock, new Vector3(0, 0, 0), Quaternion.Euler(0, strikeDeg + 90, 0));
            _ = Instantiate(strikeBlock, new Vector3(0, 0, 0), Quaternion.Euler(0, strikeDeg + 180, 0));
            _ = Instantiate(strikeBlock, new Vector3(0, 0, 0), Quaternion.Euler(0, strikeDeg + 270, 0));
            isStrike = false;
        }
        strikeDeg++;
    }

    public void Damage(float damage)
    {
        hp -= damage;
    }
    private float ToRadian(float angle)
    {
        return angle * (float)Math.PI / 180f;
    }
    public int PopCount()
    {
        return enemyPop;
    }
    public void PopUp() 
    {
        enemyPop++;
    }
    public int GetEnemyCount()
    {
        return enemyQuantity;
    }
    // Start is called before the first frame update
    void Start()
    {
        sumonPos = new Vector2[enemyQuantity];
        circle = GameObject.FindWithTag("Circle").GetComponent<Transform>();
        tf=GetComponent<Transform>();
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        sumonCountBuff = (int)(sumonCount * 60);
        strikeDeg = 0;
        isLook = true;

    }

    // Update is called once per frame
    void Update()
    {
        BossAction();
        
    }
}
