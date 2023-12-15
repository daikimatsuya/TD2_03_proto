using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    new Transform transform;
    private Transform playerTransform;

    public float offset;
   
    private void CameraMove()
    {
      

    }
    // Start is called before the first frame update
    void Start()
    {
        playerTransform=GameObject.FindWithTag("Player").GetComponent<Transform>();
        transform=GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        CameraMove();
    }
}
