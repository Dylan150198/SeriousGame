using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// This class loads specific songs, deserializes json data to a TargetCollection, and then passes it to the StartSong method in OnMusicSpawner to start playing.
/// </summary>

[System.Serializable]
public class SongLoader : MonoBehaviour
{
    private TargetCollection targetCollection;
    public OnMusicSpawner musicSpawner;

    public void LoadSong(Song song)
    {
        string songName = song.path;
        TextAsset file = Resources.Load(songName) as TextAsset;
        string content = file.ToString();
        targetCollection = JsonUtility.FromJson<TargetCollection>(content);
        musicSpawner.StartSong(targetCollection, songName, song.bpm);
    }
}
