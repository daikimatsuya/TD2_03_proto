using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    new Transform transform;

    private Vector2 circleSize;

    public float circleSizeupSpeed;
    public Vector2 standardCircle;


    private void CircleControll()
    {
        CircleSizeControll();
    }
    private void CircleSizeControll()
    {
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

    private void CircleScale(Vector2 scale)
    {
        transform.localScale = new Vector3(scale.x, 1, scale.y);
    }
    public void CircleSizeUp(Vector2 size)
    {
        circleSize = new Vector2(circleSize.x + size.x, circleSize.y + size.y);
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
