using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
	public static EventHandler current;



	private void Awake()
	{
		current = this;

	}

	public event Action OnCoinPickUp;

	public void CoinPickUp() {
		OnCoinPickUp?.Invoke();
	}
}
