using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    public TextMeshProUGUI tmpScore;
    public TextMeshProUGUI tmpBumps;
    public TextMeshProUGUI tmpTimeLeft;

    float currentTime = 0f;
    float startingTime = 60f;

    private int playerHits = 0;

    // Start is called before the first frame update
    void Start()
    {
        EventSystem.current.OnPlayerHit += OnPlayerHit;
        currentTime = startingTime;
    }

    private void OnPlayerHit()
    {
        playerHits++;
        tmpBumps.SetText(playerHits.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if (MazeGame.state == GameState.STARTED)
        {
            currentTime -= 1 * Time.deltaTime;
            if (currentTime <= 0)
            {
                currentTime = 0;
            }

            tmpTimeLeft.SetText(Math.Round(currentTime, 1).ToString());
        }
    }
}
