using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightMovement : MonoBehaviour
{
	public LightController controller;
	public float Speed = 40f;
	private float horizontalMove = 0f;
	private float verticalMove = 0f;
	private bool v_Move = false;
	public Joystick joystick;
	public GameObject player;
	public Light2D light;

	private bool isDead;

	private void Start()
	{
		PlatformEventHandler.current.OnEnemyHit += OnEnemyHit;
	}

	private void OnEnemyHit()
	{
		controller.transform.position = player.transform.position;
		isDead = true;
	}

	// Update is called once per frame
	private void Update()
	{
		if (isDead)
		{
			if (light.pointLightOuterRadius >= 0)
				light.pointLightOuterRadius -= Time.deltaTime;

			if (light.pointLightInnerRadius >= 0)
				light.pointLightInnerRadius -= Time.deltaTime;

			if (light.pointLightInnerRadius <= 0 && light.pointLightOuterRadius <= 0)
				PlatformEventHandler.current.DeadScenePlayed();
		}


		if (joystick.Horizontal >= .3f )
		{
			horizontalMove = Speed;
		}
		else if (joystick.Horizontal <= -.3f)
		{
			horizontalMove = -Speed;
		}
		else
		{
			horizontalMove = 0f;
		}


		if (joystick.Vertical >= 0.3f)
		{
			verticalMove = Speed;
		}
		else if (joystick.Vertical <= -.3f)
		{
			verticalMove = -Speed;
		}
		else
		{
			verticalMove = 0f;
		}
	}



	private void FixedUpdate()
	{
		controller.Move(horizontalMove * Time.fixedDeltaTime, verticalMove * Time.fixedDeltaTime);

	}
}

