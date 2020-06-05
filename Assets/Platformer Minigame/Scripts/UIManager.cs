using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject panelMenu;
    public GameObject GameHUD;

    public ScoreManager ScoreManager;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textTime;
    public TextMeshProUGUI textDied;

    float countdownTime = 0f;
    float countDownStart = 10f;

    private int score;

    // Start is called before the first frame update
    void Start()
    {
        countdownTime = countDownStart;
        PlatformEventHandler.current.OnGameStateChanged += OnGameStateChanged;
        PlatformEventHandler.current.OnDeadScenePlayed += OnDeadScenePlayed;
    }

	private void OnDeadScenePlayed()
	{
        textDied.text = "Je bent dood";

    }

	private void OnGameStateChanged(GameState state)
	{
        
    }

    public void OnStartClicked()
    {
        PlatformEventHandler.current.GameStateChanged(GameState.STARTED);
        panelMenu.SetActive(false);
        GameHUD.SetActive(true);
    }

	// Update is called once per frame
	void Update()
    {
        if (ScoreManager.score != score)
        {
            score = ScoreManager.score;
            textScore.text = "Score: " + score.ToString();
        }

        if (PlatformManager.currentState == GameState.STARTED)
        {
            countdownTime -= 1 * Time.deltaTime;
            if (countdownTime <= 1)
            {
                countdownTime = 0;
                PlatformEventHandler.current.GameStateChanged(GameState.STOPPED);
            }
            textTime.SetText(Math.Round(countdownTime).ToString());
        }

    }
}
