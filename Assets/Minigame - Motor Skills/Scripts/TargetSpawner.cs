using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject circle;
    // Start is called before the first frame update
    void Start()
    {
        var spawnPoint = transform.position;
        var pieceRotation = Quaternion.AngleAxis(90, Vector3.right);
        Instantiate(circle, new Vector3(spawnPoint.x, spawnPoint.y, spawnPoint.z), pieceRotation);
    }
}
