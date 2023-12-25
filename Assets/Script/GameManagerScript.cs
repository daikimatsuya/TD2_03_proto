using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    private Circle circle;
    // Start is called before the first frame update
    public void CircleSizeUp(Vector2 size)
    {
        circle.CircleSizeUp(size);
    }
    void Start()
    {
        circle = GameObject.FindWithTag("Circle").GetComponent<Circle>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
