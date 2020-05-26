using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class MovingPlatform : MonoBehaviour
{
    public float moveSpeed = 3f;
    public bool movePositive = true;
    public bool isMovingHorizontal = true;
    public float max;
    public float min;

    private float localMax;
    private float localMin;

    // Start is called before the first frame update
    void Start()
    {
        if (isMovingHorizontal)
        {
            localMax = transform.position.x + max;
            localMin = transform.position.x - min;
        }
        else
        {
            localMax = transform.position.y + max;
            localMin = transform.position.y - min;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isMovingHorizontal)
        {

            if (transform.position.x > max)
                movePositive = false;
            if (transform.position.x < min)
                movePositive = true;

            if (movePositive)
                transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
            else
                transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }
        else
        {
            if (transform.position.y > localMax)
                movePositive = false;
            if (transform.position.y < localMin)
                movePositive = true;

            if (movePositive)
                transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
            else
                transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
        }
    }
}
