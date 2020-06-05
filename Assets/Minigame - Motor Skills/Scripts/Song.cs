[System.Serializable]
public class Song 
{
    public string songName;
    public string difficulity;
    public string path;
    public int bpm;
}

[System.Serializable]
public class SongRoot
{
    public Song[] songs;
}

