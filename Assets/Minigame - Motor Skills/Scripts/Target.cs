using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class describes a single target and where to spawn it, and when
/// </summary>

[Serializable]
public class Target 
{
    //public OnMusicSpawner spawner;
    public string spawner;
    public string spawnPosition;
    public float timeInMs;

}
