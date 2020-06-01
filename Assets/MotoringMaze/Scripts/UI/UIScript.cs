using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI countdownText;

    float countdownTime = 0f;
    float countDownStart = 3f;

    void Start()
    {
        countdownTime = countDownStart;
    }

    private void Update()
    {
        if (MazeGame.state == GameState.LOADED)
        {
            countdownTime -= 1 * Time.deltaTime;
            if (countdownTime <= 1)
            {
                countdownTime = 0;
                panel.SetActive(false);
                EventSystem.current.GameStateChanged(GameState.STARTED);
            }
            countdownText.SetText(Math.Round(countdownTime).ToString());
        }

        if (MazeGame.state == GameState.STOPPED)
        {
            
        }
    }
}
