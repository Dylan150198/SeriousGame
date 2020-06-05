using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawners;
    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public float decreaseTime;
    public float minTime = 0.65f;
    public SongLoader songLoader;

    // Start is called before the first frame update
    void Start()
    {
        if (SongList.selectedSong != null) {
            songLoader.LoadSong(SongList.selectedSong);
        }
    }

    //// Update is called once per frame
    //void Update()
    //{
    //    if(timeBtwSpawn <= 0)
    //    {
    //        int rand = Random.Range(0, spawners.Length);
    //        var pieceRotation = Quaternion.AngleAxis(90, Vector3.right);
    //        Instantiate(spawners[rand], transform.position, pieceRotation);
    //        timeBtwSpawn = startTimeBtwSpawn;
    //        if (startTimeBtwSpawn > minTime)
    //        {
    //            startTimeBtwSpawn -= decreaseTime;
    //        }
    //    }
    //    else
    //    {
    //        timeBtwSpawn -= Time.deltaTime;
    //    }
    //}
}
