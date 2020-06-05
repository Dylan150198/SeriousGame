using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public GameObject panelCountdown;
    public TextMeshProUGUI countdownText;

    public TextMeshProUGUI tmpScore;
    public TextMeshProUGUI tmpBumps;
    public TextMeshProUGUI tmpTimeLeft;

    float currentGameTime = 0f;
    float startingGameTime = 60f;

    private int playerHits = 0;

    float countdownTime = 0f;
    float countDownStart = 3f;

    void Start()
    {
        EventSystem.current.OnPlayerHit += OnPlayerHit;
        EventSystem.current.OnGameStateChanged += OnGameStateChanged;
        currentGameTime = startingGameTime;
        countdownTime = countDownStart;
    }

	private void OnGameStateChanged(GameState gameState)
	{
        if (gameState == GameState.STOPPED)
        {
            WsClient.instance.SendScore(MinigameState.MAZE, GameScore.CalculateScore(currentGameTime, playerHits));
        }
    }

	private void OnPlayerHit()
	{
        playerHits++;
        tmpBumps.SetText(playerHits.ToString());
    }

	void Update()
    {
        if (MazeGame.state == GameState.LOADED)
        {
            
            countdownTime -= 1 * Time.deltaTime;
            if (countdownTime <= 1)
            {
                countdownTime = 0;
                panelCountdown.SetActive(false);
                EventSystem.current.GameStateChanged(GameState.STARTED);
            }
            countdownText.SetText(Math.Round(countdownTime).ToString());
        }

        if (MazeGame.state == GameState.STARTED)
        {
            currentGameTime -= 1 * Time.deltaTime;
            if (currentGameTime <= 0)
            {
                currentGameTime = 0;
            }

            tmpTimeLeft.SetText(Math.Round(currentGameTime, 1).ToString());
        }
    }
}
