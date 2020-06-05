using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySong : MonoBehaviour
{
    public AudioClip[] songs;
    public AudioSource myAudio;

    public void FindAndPlay(string audio)
    {
        foreach (var item in songs)
        {
            if(item.name == audio)
            {
                myAudio.PlayOneShot(item);
                break;
            }
        }
    }

}
