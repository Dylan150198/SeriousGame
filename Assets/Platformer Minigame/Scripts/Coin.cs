using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
	private AudioSource audioSource;
	public UnityEvent onCoinPickUp;
	private SpriteRenderer spriteRenderer;

	private bool hasTriggered = false;


	public void Awake()
	{
		audioSource = GetComponent<AudioSource>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!hasTriggered)
		{
			PlatformEventHandler.current.CoinPickUp();
			spriteRenderer.enabled = false;
			audioSource.Play();
			hasTriggered = true;
		}

	}
	// Update is called once per frame
	void Update()
    {
		if (hasTriggered)
		{
			if (!audioSource.isPlaying)
			{
				Destroy(gameObject);
			}
		}
    }
}
