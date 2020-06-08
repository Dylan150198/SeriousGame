using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class LightController : MonoBehaviour
{
	
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
	private Rigidbody2D m_Rigidbody2D;
	
	private Vector3 m_Velocity = Vector3.zero;

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}

	public void Move(float move, float v_move)
	{

			Vector3 targetVelocity = new Vector2(move * 5f, m_Rigidbody2D.velocity.y);
			// And then smoothing it out and applying it to the light
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
			
			Vector3 targetVelocityVertical = new Vector2(m_Rigidbody2D.velocity.x, v_move * 5f);
			// And then smoothing it out and applying it to the light
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocityVertical, ref m_Velocity, m_MovementSmoothing);
	}
}
