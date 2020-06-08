using Project.Global;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SongEnded : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI flavourText;
    void Start()
    {
        int highscore;
        // Get the current song
        string songName = PlayerPrefs.GetString("CurrentSong");
        // Get the players score
        int score = PlayerPrefs.GetInt("CurrentScore" + songName);

        // Upload my score for the leaderbord
        WsClient.instance.SendScore(MinigameState.MOTORSKILLS, score);

        // Have I scored this before?
        if(PlayerPrefs.HasKey("CurrentHighScore" + songName))
        {
            highscore = PlayerPrefs.GetInt("CurrentHighScore" + songName);
            // Is it higher?
            if (score > highscore)
            {
                // I scored higher
                PlayerPrefs.SetInt("CurrentHighScore" + songName, score);
                // Display a "Your new highscore!" text
                scoreText.text = "Your score: " + score.ToString();
                highScoreText.text = "This is a new high score of : " + score.ToString();
            }
            else
            {
                // Display score
                scoreText.text = "Score: " + score.ToString();
                // Display highscore
                highScoreText.text = "Highscore:  " + highscore.ToString();
            }
        }
        else
        {
            PlayerPrefs.SetInt("CurrentHighScore" + songName, score);
            scoreText.text = "Score: " + score.ToString();
            highScoreText.text = "Highscore: " + score.ToString();
        }
    }
}
