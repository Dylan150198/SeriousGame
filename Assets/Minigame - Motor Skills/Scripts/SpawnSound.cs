using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSound : MonoBehaviour
{
    public AudioClip[] clips;

    private void Start()
    {
        int clipPick = Random.Range(0, clips.Length);
        GetComponent<AudioSource>().clip = clips[clipPick];
        GetComponent<AudioSource>().Play();
    }

}
