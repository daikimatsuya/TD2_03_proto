using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private bool isSumon;
    public  float sumonCount;
    private int sumonCountBuff;
    private void BossAction()
    {

    }
    private void Attack()
    {

    }
    private void SumonEnemy()
    {
        if(Input.GetKeyDown(KeyCode.E)) 
        {
            isSumon = true;
        }
        if(isSumon)
        {
            sumonCountBuff--;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        sumonCountBuff = (int)(sumonCount * 60);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
