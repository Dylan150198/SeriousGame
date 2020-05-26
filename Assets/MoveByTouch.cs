using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByTouch : MonoBehaviour
{
	public CharacterController2D controller;
	public Animator animator;
	private System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
	public float runSpeed = 40f;
	private float horizontalMove = 0f;
	private bool jump = false;

	public Joystick joystick;


	// Update is called once per frame
	private void Update()
	{

		horizontalMove = joystick.Horizontal * runSpeed;
		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			animator.SetBool("IsJumping", true);
		}

	}

	public void OnLanding()
	{
		animator.SetBool("IsJumping", false);
	}

	private void FixedUpdate()
	{

		controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
		jump = false;

	}
}

