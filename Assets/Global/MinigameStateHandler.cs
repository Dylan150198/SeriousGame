using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameStateHandler : MonoBehaviour
{
	public MinigameState currentState;
	public MinigameState previousState;

	public static MinigameStateHandler instance;

	private void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}

	private void Start()
	{
		currentState = MinigameState.MAZE;
	}

	public void LoadIntermission()
	{
		previousState = currentState;
		SceneManager.LoadScene("IntermissionMenu");
	}

	public void OnNextGameClicked()
	{
		currentState += 1;
		switch (currentState)
		{
			case MinigameState.PLATFORM:
				SceneManager.LoadScene("Platformer");
				break;
			case MinigameState.CONNECTFOUR:
				SceneManager.LoadScene("ConnectFour");
				break;
			case MinigameState.MAZE:
				SceneManager.LoadScene("MotoringMazeMenu");
				break;
			case MinigameState.BLURRY:
				SceneManager.LoadScene("BlurryApp");
				break;
			case MinigameState.MOTORSKILLS:
				SceneManager.LoadScene("MotorSkills_SongSelection");
				break;
			default:
				break;
		}
	}
}

public enum MinigameState
{
	MAZE = 1,
	PLATFORM = 2,
	CONNECTFOUR = 3,
	BLURRY = 4,
	MOTORSKILLS = 5,
}