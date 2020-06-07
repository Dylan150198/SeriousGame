using System;

[Serializable]
public class ScoreDTO
{
	public int score;
	public string username;
	public string playerid;

	public ScoreDTO()
	{

	}

	public ScoreDTO(int score, string username, string playerid)
	{
		this.score = score;
		this.username = username;
		this.playerid = playerid;
	}
}