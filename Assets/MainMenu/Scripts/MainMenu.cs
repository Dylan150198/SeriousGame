using Project.Global;
using Project.Global.Models;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public GameObject panelMain;
	public GameObject panelJoin;
	public GameObject panelCreate;
	public GameObject panelLobby;
	public GameObject panelFreePlay;

	public TMPro.TMP_InputField inputRoomJoin;
	public TMPro.TMP_InputField inputNameJoin;
	public TMPro.TMP_InputField inputNameCreate;

	public TMPro.TextMeshProUGUI roomId;
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

	private void OnSelfConnected(string roomid)
	{
		previousPanel = currentPanel;
		previousPanel.SetActive(false);
		currentPanel = panelLobby;
		currentPanel.SetActive(true);
		roomId.text = "Kamer ID: " + roomid;
		GUIUtility.systemCopyBuffer = WsClient.instance.Player.roomid;
	}

	private void OnPlayerJoined(PlayerDTO[] players)
	{
		playerList.text = "";
		for (int i = 0; i < players.Length; i++)
			playerList.text += "<color=" + chatColors[i] +"> " + players[i].username +" </color> "  + "\n";
	}

	void Update() {

		if (!WsClient.instance.IsConnected && currentPanel != panelFreePlay)
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
		MinigameStateHandler.instance.isFreePlay = false;
		previousPanel = currentPanel;
		previousPanel.SetActive(false);
		currentPanel = panelJoin;
		currentPanel.SetActive(true);
	}

	public void OnCreatePanelClick()
	{
		MinigameStateHandler.instance.isFreePlay = false;
		previousPanel = currentPanel;
		previousPanel.SetActive(false);
		currentPanel = panelCreate;
		currentPanel.SetActive(true);
	}

	public void OnFreePlayClicked()
	{
		MinigameStateHandler.instance.isFreePlay = true;
		WsClient.instance.Close();
		previousPanel = currentPanel;
		previousPanel.SetActive(false);
		currentPanel = panelFreePlay;
		currentPanel.SetActive(true);
	}

	public void OnFreePlayGameClicked(int state)
	{
		MinigameState minigame = (MinigameState) state;
		switch (minigame)
		{
			case MinigameState.MAZE:
				SceneManager.LoadScene("MotoringMazeMenu");
				break;
			case MinigameState.CONNECTFOUR:
				SceneManager.LoadScene("ConnectFourLoadingScreen");
				break;
			case MinigameState.PLATFORM:
				SceneManager.LoadScene("Platformer");
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

	public void OnJoinClick()
	{
		WsClient.instance.OnJoinClicked(inputRoomJoin.text, inputNameJoin.text);
	}
	public void OnCreateClick()
	{
		WsClient.instance.OnCreateClicked(inputNameCreate.text);
	}
}
