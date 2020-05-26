using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnPointPicker : MonoBehaviour
{
    public GameObject[] spawnpoints;
    public GameObject circle;
    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, spawnpoints.Length);
        var spawnPoint = spawnpoints[rand].transform.position;
        var pieceRotation = Quaternion.AngleAxis(90, Vector3.right);
        Instantiate(circle, new Vector3(spawnPoint.x, spawnPoint.y, spawnPoint.z), pieceRotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
