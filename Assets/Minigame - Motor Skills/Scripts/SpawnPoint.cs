using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject circle;
    public bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        var pieceRotation = Quaternion.AngleAxis(90, Vector3.right);
        var instantiatedCircle = Instantiate(circle, transform.position, pieceRotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
