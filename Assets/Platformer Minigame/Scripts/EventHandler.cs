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

	public void CoinPickUp() {
		OnCoinPickUp?.Invoke();
	}
}
