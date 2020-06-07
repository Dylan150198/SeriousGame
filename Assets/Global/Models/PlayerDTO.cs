using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Global.Models
{
	[Serializable]
	public class PlayerDTO
	{
		public string username;
		public string roomid;
		public string playerid;

		public PlayerDTO()
		{

		}

		public PlayerDTO(string playerid, string roomid, string username)
		{
			this.playerid = playerid;
			this.roomid = roomid;
			this.username = username;
		}
	}
}
