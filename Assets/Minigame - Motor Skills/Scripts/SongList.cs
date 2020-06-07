using Project.Global;
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
    public GameObject ScrollView;
    private int i = 0;
    private int distanceBetweenButtons = 0;
    public Image black;
    public Animator animator;
    public static Song selectedSong;

    // Start is called before the first frame update
    void Start()
    {
        GameObject menuButton = GameObject.Find("BackToMenuButton");
        Button menuButtonComponent = menuButton.GetComponent<Button>();
        if (MinigameStateHandler.instance.isFreePlay)
        {
            menuButtonComponent.interactable = true;
        }
        else
        {
            menuButtonComponent.interactable = false;
        }

        menuButtonComponent.onClick.AddListener(() => MenuButtonClicked());


        TextAsset file = Resources.Load("songList") as TextAsset;
        string content = file.ToString();
        songRoot = JsonUtility.FromJson<SongRoot>(content);
        foreach (var item in songRoot.songs)
        {
            GameObject button = (GameObject) Instantiate(prefabButton);
            //button.transform.SetParent(canvas, false);
            button.transform.SetParent(ScrollView.transform);
            button.transform.localScale = new Vector3(1, 1, 1);

            //var posButton = new Vector3(ScrollView.transform.position.x, ScrollView.transform.position.y - distanceBetweenButtons, ScrollView.transform.position.z);
          

            int highscore = 0;

            //if (PlayerPrefs.HasKey("CurrentHighScore" + item.songName))
            //{
                highscore = PlayerPrefs.GetInt("CurrentHighScore" + item.path);
            //}

            var posButton = new Vector3(button.transform.position.x, button.transform.position.y - distanceBetweenButtons, button.transform.position.z);

            var buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = item.songName + " | " + item.difficulity + " | " + "Highscore: " + highscore;

            button.transform.position = posButton;
            //button.transform.position.y = distanceBetweenButtons;
       

            Button tempButton = button.GetComponent<Button>();
            int tempInt = i;

            i++;
            distanceBetweenButtons += 200;

            tempButton.onClick.AddListener(() => ButtonClicked(tempInt));
        }
    }


    void MenuButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
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
        SceneManager.LoadScene("MotorSkills_SongPlaying");
    }
}
