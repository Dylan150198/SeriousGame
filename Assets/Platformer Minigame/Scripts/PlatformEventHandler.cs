using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformEventHandler : MonoBehaviour
{
	public static PlatformEventHandler current;



	private void Awake()
	{
		current = this;

	}

	public event Action OnCoinPickUp;
	public event Action OnEnemyHit;
	public event Action<GameState> OnGameStateChanged;
	public event Action OnDeadScenePlayed;

	public void DeadScenePlayed()
	{
		OnDeadScenePlayed?.Invoke();
	}

	public void GameStateChanged(GameState state)
	{
		OnGameStateChanged?.Invoke(state);
	}

	public void CoinPickUp() {
		OnCoinPickUp?.Invoke();
	}

	public void EnemyHit()
	{
		OnEnemyHit?.Invoke();
	}
}
