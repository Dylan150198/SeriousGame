using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
	public GameObject ScoreManager;
	public GameObject UIManager;


	public static GameState currentState;

    // Start is called before the first frame update
    void Start()
    {
		currentState = GameState.MENU;
		PlatformEventHandler.current.OnGameStateChanged += OnGameStateChanged;
	
    }

	private void OnGameStateChanged(GameState state)
	{
		currentState = state;
	}


	// Update is called once per frame
	void Update()
    {
        
    }
}
