using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public CharacterController2D controller;
	public Animator animator;
	public float runSpeed = 40f;
	private float horizontalMove = 0f;
	private bool jump = false;
	public Joystick joystick;

	private void Start()
	{
		PlatformEventHandler.current.OnEnemyHit += OnEnemyHit;
	}

	private void OnEnemyHit()
	{
		animator.enabled = false;
	}


	// Update is called once per frame
	private void Update()
    {

		if (joystick.Horizontal >= .3f)
		{
			horizontalMove = runSpeed;
		}
		else if (joystick.Horizontal <= -.3f)
		{
			horizontalMove = -runSpeed;
		}
		else
		{
			horizontalMove = 0f;
		}

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		float verticalMove = joystick.Vertical;


		if (verticalMove >= .8f && !animator.GetBool("IsJumping"))
		{
			jump = true;
			animator.SetBool("IsJumping", true);
		}

	}



	public void OnLanding() {
		animator.SetBool("IsJumping", false);

		
	}

	private void FixedUpdate()
	{
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
		jump = false;
	}
}

