using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.MainMenu.Scripts
{
	[Serializable]
	public class MinigamePlayer
	{
		public string username;
		public string roomid;
		public string playerid;

		public MinigamePlayer()
		{

		}

			public MinigamePlayer(string playerid, string roomid, string username)
		{
			this.playerid = playerid;
			this.roomid = roomid;
			this.username = username;
		}
	}
}
