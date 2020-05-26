using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGame : MonoBehaviour
{
    public static GameState state;
    void Start()
    {
        EventSystem.current.OnGameStateChanged += OnGameStateChanged;
        EventSystem.current.GameStateChanged(GameState.LOADED);
        Debug.Log("dpi: " + Screen.dpi);
        Screen.orientation = ScreenOrientation.Portrait;
    }

    private void OnGameStateChanged(GameState gameState)
    {
        state = gameState;
    }
}
