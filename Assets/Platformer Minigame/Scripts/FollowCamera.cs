using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

	private Cinemachine.CinemachineVirtualCamera camera;
	GameObject CameraBounds;
	private Vector2 resolution;

	// Start is called before the first frame update
	void Start()
    {
		camera = GetComponent<CinemachineVirtualCamera>();
		resolution = new Vector2(Screen.width, Screen.height);
		GenerateCollidersAcrossScreen();
		Screen.orientation = ScreenOrientation.Landscape;
		
	}
	void GenerateCollidersAcrossScreen()
	{
		CameraBounds = new GameObject();
		CameraBounds.transform.parent = gameObject.transform;
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

	void Update()
	{
		if (resolution.x != Screen.width || resolution.y != Screen.height)
		{
			Destroy(CameraBounds);
			GenerateCollidersAcrossScreen();
			resolution = new Vector2(Screen.width, Screen.height);
		}
	}
}
