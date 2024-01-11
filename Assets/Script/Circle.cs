using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    new Transform transform;

    private Vector2 circleSize;

    public float circleSizeupSpeed;
    public float circleSizedownSpeed;
    public Vector2 standardCircle;
    public float stint;


    private void CircleControll()
    {
        CircleSizeControll();
    }
    private void CircleSizeControll()
    {
        FixedPos();
        SizeDown();
        if (Input.GetKey(KeyCode.UpArrow))
        {
            circleSize = new Vector2(circleSize.x + circleSizeupSpeed, circleSize.y + circleSizeupSpeed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            circleSize = new Vector2(circleSize.x - circleSizeupSpeed, circleSize.y - circleSizeupSpeed);
        }
        CircleScale(circleSize);
    }
    private void FixedPos()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    private void CircleScale(Vector2 scale)
    {
        transform.localScale = new Vector3(scale.x, 1, scale.y);
    }
    public void CircleSizeUp(Vector2 size)
    {
        if (size.x > 2)
        {
            size.x = 2;
        }
        if (size.y>2)
        {
            size.y = 2;
        }
        circleSize = new Vector2(circleSize.x + (size.x/3)/(circleSize.x/stint), circleSize.y + (size.y/3)/(circleSize.y/stint));
    }
    private void SizeDown()
    {
        if(circleSize.x > standardCircle.x)
        {
            circleSize = new Vector2(circleSize.x - circleSizedownSpeed, circleSize.y - circleSizedownSpeed);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();

        circleSize = standardCircle;
    }

    // Update is called once per frame
    void Update()
    {
        CircleControll();
    }
}
