using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 0.1f;
    public bool forward = true;

    void Start()
    {
        speed = speed * 1000;
    }

    // Update is called once per frame
    void Update()
    {
        if(forward)
            transform.Rotate(Vector3.forward * speed * Time.deltaTime);
        else
            transform.Rotate(Vector3.back * speed * Time.deltaTime);
    }
}
