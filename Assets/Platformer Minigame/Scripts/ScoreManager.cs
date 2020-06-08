using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
	private int chestValue = 50;
	private int coinValue = 5;
	public int score = 0;
	public int chestCount = 0;


	public void Start()
	{
		PlatformEventHandler.current.OnCoinPickUp += OnCoinPickUp;
		PlatformEventHandler.current.OnChestPickUp += OnChestPickUp;
	}
	private void OnCoinPickUp()
	{
		score += coinValue;
		
	}

	private void OnChestPickUp()
	{
		score += chestValue;
		chestCount += 1; 

	}

	private void OnDestroy()
	{
		PlatformEventHandler.current.OnCoinPickUp -= OnCoinPickUp;
	PlatformEventHandler.current.OnChestPickUp += OnChestPickUp;

	}

}
