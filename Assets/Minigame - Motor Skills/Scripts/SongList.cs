using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[Serializable]
public class SongList : MonoBehaviour
{
    private SongRoot songRoot;
    public RectTransform canvas;
    public GameObject prefabButton;
    private int i = 0;
    private int distanceBetweenButtons = 0;
    public Image black;
    public Animator animator;
    public static Song selectedSong;

    // Start is called before the first frame update
    void Start()
    {
        TextAsset file = Resources.Load("songList") as TextAsset;
        string content = file.ToString();
        songRoot = JsonUtility.FromJson<SongRoot>(content);
        foreach (var item in songRoot.songs)
        {
            GameObject button = (GameObject) Instantiate(prefabButton);
            button.transform.SetParent(canvas, false);
            button.transform.localScale = new Vector3(2, 2, 2);

            var posButton = new Vector3(canvas.position.x, canvas.position.y + distanceBetweenButtons, canvas.position.z);
            var buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = item.songName + " | " + item.difficulity;
            button.transform.position = posButton;

            // get score 
            

            Button tempButton = button.GetComponent<Button>();
            int tempInt = i;

            i++;
            distanceBetweenButtons += 150;

            tempButton.onClick.AddListener(() => ButtonClicked(tempInt));
        }
    }


    void ButtonClicked(int buttonNo)
    {
        // Load a new scene with this song selected
        selectedSong = songRoot.songs[buttonNo];
        StartCoroutine(FadingLoadingScreen());
    }

    private IEnumerator FadingLoadingScreen()
    {
        animator.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        // here I should store my last score before move to level two
        // PlayerPrefs.SetInt("player_score", score);
        SceneManager.LoadScene("MotorSkills_SongPlaying", LoadSceneMode.Single);
    }
}
