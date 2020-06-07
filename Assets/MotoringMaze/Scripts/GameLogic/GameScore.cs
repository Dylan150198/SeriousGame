using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public static class GameScore
{
	public static int CalculateScore(float timeLeft, int faults)
	{
		return Convert.ToInt32(((timeLeft / 50) / (1 * faults)) * 1000);
	}
}
