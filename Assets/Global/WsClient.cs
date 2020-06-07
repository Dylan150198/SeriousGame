using Project.Global.Util;
using Project.Global.Models;
using SocketIO;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Project.Global
{
	public class WsClient : SocketIOComponent
	{
		[Header("Network Client")]
		[SerializeField]
		private Dictionary<string, string> players;
		public string playerid;
		public PlayerDTO Player { get; private set; }

		public static WsClient instance;

		public event Action<PlayerDTO[]> OnPlayerJoined;
		public event Action OnSelfConnected;
		public event Action<MinigameState[]> OnGameCompleted;
		public event Action<Dictionary<int, ScoreDTO[]>> OnScoreUpdated;
		private Dictionary<int, ScoreDTO[]> leaderbord;

		public override void Awake()
		{
			base.Awake();
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

		public override void Start()
		{
			base.Start();
			Player = new PlayerDTO();

			SetupEvents();
		}

		public override void Update()
		{
			base.Update();
		}

		private void SetupEvents()
		{
			On("open", (E) =>
			{

			});

			On("register", (E) =>
			{
				Player.playerid = E.data["playerId"].ToString().Trim('"');
			});

			On("gamecompleted", (E) =>
			{
				int[] gameIds = JsonHelper.getJsonArray<int>(E.data["games"].ToString());
				MinigameState[] minigames = gameIds.Select(o => (MinigameState)o).ToArray();
				OnGameCompleted?.Invoke(minigames);
			});

			On("scoreupdated", (E) =>
			{
				leaderbord = new Dictionary<int, ScoreDTO[]>();
				JSONObject games = E.data["leaderboard"];
				foreach (var key in games.keys)
				{
					leaderbord.Add(int.Parse(key), JsonHelper.getJsonArray<ScoreDTO>(games[key].ToString()));
				}
				OnScoreUpdated?.Invoke(leaderbord);
			});

			On("roomjoined", (E) =>
			{
				Player.roomid = E.data["roomid"].ToString().Trim('"');
				OnSelfConnected?.Invoke();
			});

			On("playerschanged", (E) =>
			{
				PlayerDTO[] players = JsonHelper.getJsonArray<PlayerDTO>(E.data["players"].ToString());
				OnPlayerJoined?.Invoke(players);
			});
		}

		public void SendScore(MinigameState gameid, int score)
		{
			JSONObject scoreObject = new JSONObject(JsonUtility.ToJson(Player));
			scoreObject.AddField("gameid", (int)gameid);
			scoreObject.AddField("score", score);
			Emit("score", scoreObject);
		}

		public void OnJoinClicked(string roomid, string username)
		{
			Player.username = username;
			Player.roomid = roomid;
			Emit("join", new JSONObject(JsonUtility.ToJson(Player)));
		}
		public void OnCreateClicked(string username)
		{
			Player.username = username;
			Emit("create", new JSONObject(JsonUtility.ToJson(Player)));
		}
	}
}

