using Project.Global;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class spawns targets
/// </summary>

[Serializable]
public class OnMusicSpawner : MonoBehaviour
{
    private TargetCollection targets;
    public string songName;
    public GameObject[] spawners;
    public GameObject[] circles;
    public PlaySong songMusicPlayer;
    public Animator animator;
    public GameObject spawnEffect;
    private Dictionary<string, GameObject> mySpawners = new Dictionary<string, GameObject>();
    public Score score;
    private bool sentScore = false;

    public void StartSong(TargetCollection targetCollection, string songName, int bpm)
    {
        mySpawners.Add("C Spawner", spawners[0]);
        mySpawners.Add("L1 Spawner", spawners[1]);
        mySpawners.Add("L2 Spawner", spawners[2]);
        mySpawners.Add("R1 Spawner", spawners[3]);
        mySpawners.Add("R2 Spawner", spawners[4]);

        // Find and start the song
        songMusicPlayer.FindAndPlay(songName);

        this.songName = songName;
 
        foreach (var item in targetCollection.targets)
        {

            //// Fade effect - WIP
            //StartCoroutine(ExecuteAfterTime(item.timeInMs - 0.5f) / bpm * 60, () => {
            //    // rework this, duplicate code
            //    GameObject spawner;
            //    mySpawners.TryGetValue(item.spawner, out spawner);
            //    GameObject spawnerPrefabInstance = Instantiate(spawner, spawner.transform.position, Quaternion.identity) as GameObject;
            //    Transform spawnPoint = spawnerPrefabInstance.GetComponentInChildren<Transform>().Find(item.spawnPosition) as Transform;
            //    Instantiate(spawnEffect, spawnPoint.transform.position, Quaternion.identity);
            //}));

            StartCoroutine(ExecuteAfterTime(item.timeInMs / bpm * 60 , () =>
            {
                //var pieceRotation = Quaternion.AngleAxis(90, Vector3.right);     
                GameObject spawner;
                mySpawners.TryGetValue(item.spawner, out spawner);
                GameObject spawnerPrefabInstance = Instantiate(spawner, spawner.transform.position, Quaternion.identity) as GameObject;
                Transform spawnPoint = spawnerPrefabInstance.GetComponentInChildren<Transform>().Find(item.spawnPosition) as Transform;
                MakeTarget(spawnPoint.transform.position, Quaternion.identity);  
            }));
        }
    }


    private void MakeTarget(Vector3 pos, Quaternion rot)
    {
        if (!checkIfPosEmpty(pos))
        {
            return;
        }
        else
        {
            int rand = UnityEngine.Random.Range(0, circles.Length);
            Instantiate(circles[rand], pos, rot);
        }
    }

    private bool checkIfPosEmpty(Vector3 targetPos)
    {
        GameObject[] allMovableThings = GameObject.FindGameObjectsWithTag("target");
        foreach (GameObject current in allMovableThings)
        {
            if (current.transform.position == targetPos)
                return false;
        }
        return true;
    }

    private IEnumerator ExecuteAfterTime(float time, Action task)
    {
        yield return new WaitForSeconds(time);
        task();
    }

    private void Update()
    {
        if (!songMusicPlayer.myAudio.isPlaying)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        if (MinigameStateHandler.instance.isFreePlay)
        {
            StartCoroutine(FreePlayEndScene(1));
        }
        else
        {
            LeaderboardEndScene();
        }
    }

    private void LeaderboardEndScene()
    {
        PlayerPrefs.SetString("CurrentSong", songName);
        PlayerPrefs.SetInt("CurrentScore" + songName, score.score);
        if (!sentScore)
        {
            WsClient.instance.SendScore(MinigameState.MOTORSKILLS, score.score);
            sentScore = true;
        }
        if (PlayerPrefs.HasKey("CurrentHighScore" + songName))
        {
            int highscore = PlayerPrefs.GetInt("CurrentHighScore" + songName);
            if (score.score > highscore)
            {
                PlayerPrefs.SetInt("CurrentHighScore" + songName, score.score);
            }
        }
 
        MinigameStateHandler.instance.LoadIntermission();
    }

    private IEnumerator FreePlayEndScene(float time)
    {
        animator.SetBool("Fade", true);
        yield return new WaitForSeconds(time);
        PlayerPrefs.SetInt("CurrentScore" + songName, score.score);
        PlayerPrefs.SetString("CurrentSong", songName);
        SceneManager.LoadScene("MotorSkills_SongEnded");
    }
}
