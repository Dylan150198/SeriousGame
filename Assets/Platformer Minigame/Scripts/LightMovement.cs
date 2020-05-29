using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMovement : MonoBehaviour
{
	public LightController controller;
	public float Speed = 40f;
	private float horizontalMove = 0f;
	private float verticalMove = 0f;
	private bool v_Move = false;
	public Joystick joystick;




	// Update is called once per frame
	private void Update()
	{

		if (joystick.Horizontal >= .3f)
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

