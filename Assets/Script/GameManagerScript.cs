using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    private Circle circle;
    private float score;
    // Start is called before the first frame update
    public void CircleSizeUp(Vector2 size)
    {
        circle.CircleSizeUp(size);
    }
    public void PulsScore(float score)
    {
        this.score += score;
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
