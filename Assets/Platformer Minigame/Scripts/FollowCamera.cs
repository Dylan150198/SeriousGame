using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

	public Cinemachine.CinemachineVirtualCamera camera;
	GameObject CameraBounds;

	// Start is called before the first frame update
	void Start()
    {
		CameraBounds = new GameObject();
		GenerateCollidersAcrossScreen();
	}
	void GenerateCollidersAcrossScreen()
	{
		
		Vector2 lDCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0f, camera.m_Lens.NearClipPlane));
		Vector2 rUCorner = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, camera.m_Lens.NearClipPlane));
		Vector2[] colliderpoints;

		
		CameraBounds.layer = 11;

		EdgeCollider2D upperEdge = CameraBounds.AddComponent<EdgeCollider2D>();
		colliderpoints = upperEdge.points;
		colliderpoints[0] = new Vector2(lDCorner.x, rUCorner.y);
		colliderpoints[1] = new Vector2(rUCorner.x, rUCorner.y);
		upperEdge.points = colliderpoints;

		EdgeCollider2D lowerEdge = CameraBounds.AddComponent<EdgeCollider2D>();
		colliderpoints = lowerEdge.points;
		colliderpoints[0] = new Vector2(lDCorner.x, lDCorner.y);
		colliderpoints[1] = new Vector2(rUCorner.x, lDCorner.y);
		lowerEdge.points = colliderpoints;

		EdgeCollider2D leftEdge = CameraBounds.AddComponent<EdgeCollider2D>();
		colliderpoints = leftEdge.points;
		colliderpoints[0] = new Vector2(lDCorner.x, lDCorner.y);
		colliderpoints[1] = new Vector2(lDCorner.x, rUCorner.y);
		leftEdge.points = colliderpoints;

		EdgeCollider2D rightEdge = CameraBounds.AddComponent<EdgeCollider2D>();

		colliderpoints = rightEdge.points;
		colliderpoints[0] = new Vector2(rUCorner.x, rUCorner.y);
		colliderpoints[1] = new Vector2(rUCorner.x, lDCorner.y);
		rightEdge.points = colliderpoints;
	}

	private void Update()
	{
		CameraBounds.transform.position = Camera.main.transform.position + new Vector3(5.55f, 1.15f, 0);
	}
}
