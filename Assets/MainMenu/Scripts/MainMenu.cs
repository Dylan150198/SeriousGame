using Assets.MainMenu.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
	public GameObject panelMain;
	public GameObject panelJoin;
	public GameObject panelCreate;
	public GameObject panelLobby;

	public TMPro.TMP_InputField inputRoomJoin;
	public TMPro.TMP_InputField inputNameJoin;
	public TMPro.TMP_InputField inputNameCreate;

	public TMPro.TextMeshProUGUI playerList;

	private GameObject previousPanel;
	private GameObject currentPanel;

	private string[] chatColors = { "#AC4EC6", "#FF8402", "#96D700", "#EBFF00", "#FF3FA6", "#2DD5C4", "#0047BB", "#69FF48", "#02BCE3" };

	private void Start()
	{
		Screen.orientation = ScreenOrientation.Portrait;
		currentPanel = panelMain;

		WsClient.instance.OnPlayerJoined += OnPlayerJoined;
		WsClient.instance.OnSelfConnected += OnSelfConnected;
	}

	private void OnSelfConnected()
	{
		previousPanel = currentPanel;
		previousPanel.SetActive(false);
		currentPanel = panelLobby;
		currentPanel.SetActive(true);
	}

	private void OnPlayerJoined(MinigamePlayer[] players)
	{
		playerList.text = "";
		for (int i = 0; i < players.Length; i++)
			playerList.text += "<color=" + chatColors[i] +"> " + players[i].username +" </color> "  + "\n";
	}

	void Update() {

		if (!WsClient.instance.IsConnected)
		{
			WsClient.instance.Connect();
		}
			
		if (Input.GetKeyDown(KeyCode.Escape))
		{

			if (currentPanel == panelLobby)
			{
				WsClient.instance.Close();
				previousPanel = panelMain;
				playerList.text = "";
			}
			currentPanel.SetActive(false);
			previousPanel.SetActive(true);
			currentPanel = previousPanel;
		}
	}

	public void OnJoinMenuClick()
	{
		previousPanel = currentPanel;
		previousPanel.SetActive(false);
		currentPanel = panelJoin;
		currentPanel.SetActive(true);
	}

	public void OnCreatePanelClick()
	{
		previousPanel = currentPanel;
		previousPanel.SetActive(false);
		currentPanel = panelCreate;
		currentPanel.SetActive(true);
	}

	public void OnJoinClick()
	{
		WsClient.instance.OnJoinClicked(inputRoomJoin.text, inputNameJoin.text);
	}
	public void OnCreateClick()
	{
		WsClient.instance.OnCreateClicked(inputNameCreate.text);
	}
}
