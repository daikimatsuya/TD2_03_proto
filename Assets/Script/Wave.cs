using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    new Transform transform;
    Rigidbody rb;
    private Transform playerPos;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        playerPos = GameObject.FindWithTag("Player").GetComponent<Transform>();

        transform.rotation = playerPos.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
