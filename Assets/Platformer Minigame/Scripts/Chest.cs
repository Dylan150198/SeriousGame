using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Chest : MonoBehaviour
{
	private AudioSource audioSource;
	public UnityEvent onChestPickUp;
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
			PlatformEventHandler.current.ChestPickUp();
			spriteRenderer.enabled = false;
			audioSource.Play();
			hasTriggered = true;
		}

	}

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
