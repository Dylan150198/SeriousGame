using Project.Global;
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
    public TextMeshProUGUI textChest;
    public TextMeshProUGUI textTimeUp;

    private bool hasEnded = false;

    float countdownTime = 0f;
    float countDownStart = 60f;

    private int score;
    private int chestCount;
    private int chestAmount = 3;

    // Start is called before the first frame update
    void Start()
    {
        countdownTime = countDownStart;
        PlatformEventHandler.current.OnDeadScenePlayed += OnDeadScenePlayed;
    }

	private void OnDeadScenePlayed()
	{ 
        if (!hasEnded)
        {
            hasEnded = true;
            textDied.text = "Je bent dood";
            Invoke("LoadLeaderbord", 2);
        }
    }

    void LoadLeaderbord()
    {
        WsClient.instance.SendScore(MinigameState.PLATFORM, score);
        MinigameStateHandler.instance.LoadIntermission();
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

        if (ScoreManager.chestCount != chestCount)
        {
            chestCount = ScoreManager.chestCount;
            textChest.text = chestCount.ToString() + "/" + chestAmount.ToString();
        }

        if (PlatformManager.currentState == GameState.STARTED && countdownTime >= 1)
        {
            countdownTime -= 1 * Time.deltaTime;
            if (countdownTime <= 1)
            {
                countdownTime = 0;
                PlatformEventHandler.current.GameStateChanged(GameState.STOPPED);
                if (!hasEnded)
                {
                    hasEnded = true;
                    textTimeUp.text = "Tijd is om!";
                    Invoke("LoadLeaderbord", 2);
                }
            }
            textTime.SetText(Math.Round(countdownTime).ToString());
        }

    }
}
