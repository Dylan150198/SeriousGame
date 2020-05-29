using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
	public int Score = 0;

    // Start is called before the first frame update
    void Start()
    {
		EventHandler.current.OnCoinPickUp += OnCoinPickUp;
    }

	private void OnCoinPickUp()
	{
		Score += 5;
	}

	private void OnDestroy()
	{
		EventHandler.current.OnCoinPickUp -= OnCoinPickUp;
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
