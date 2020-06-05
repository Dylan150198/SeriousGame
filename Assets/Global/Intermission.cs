using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using System.Threading;

public class Intermission : MonoBehaviour
{
	public TextMeshProUGUI buttonText;
	public TextMeshProUGUI scoreList;
	public TextMeshProUGUI title;
	public Button button;

	private MinigameStateHandler sh;

    void Start()
    {
		button.enabled = false;
        WsClient.instance.OnGameCompleted += OnGameCompleted;
		WsClient.instance.OnScoreUpdated += OnScoreUpdated;
		sh = MinigameStateHandler.instance;
		SetTextContext();
	}

	public void OnNextClicked()
	{
		sh.OnNextGameClicked();
	}

	private void OnScoreUpdated(Dictionary<int, ScoreDTO[]> leaderbord)
	{
		scoreList.text = "";
		int count = 0;
		foreach (var score in leaderbord[(int)sh.currentState])
		{
			count++;
			string top = "<sprite=" + (count - 1) + ">" + count + ". " + score.username + " (" + score.score + ")\n";
			string normal = count + ". " + score.username + " (" + score.score + ")\n";

			scoreList.text += count < 4 ? top : normal;
		}
		
	}

	private void SetTextContext()
	{
		switch (sh.currentState)
		{
			case MinigameState.MAZE:
				title.text = "Motoring Maze";
				break;
			case MinigameState.PLATFORM:
				title.text = "Peeping Platformer";
				break;
			case MinigameState.CONNECTFOUR:
				title.text = "Can't four";
				break;
			case MinigameState.BLURRY:
				title.text = "Blurry vision";
				break;
			case MinigameState.MOTORSKILLS:
				title.text = "Motoring Skills";
				break;
			default:
				title.text = "errors";
				break;
		}
	}

	private void OnGameCompleted(MinigameState[] minigames)
	{
		if (minigames.Contains(sh.currentState))
		{
			button.enabled = true;
		}
	}
}
