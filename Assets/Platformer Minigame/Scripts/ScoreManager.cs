using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

	private int coinValue = 5;
	public int score = 0;

	public void Start()
	{
		PlatformEventHandler.current.OnCoinPickUp += OnCoinPickUp;
	}
	private void OnCoinPickUp()
	{
		score += coinValue;
	}

	private void OnDestroy()
	{
		PlatformEventHandler.current.OnCoinPickUp -= OnCoinPickUp;
	}
}
