using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

	public Cinemachine.CinemachineVirtualCamera camera;
	private EdgeCollider2D edgeCollider2D;
	private float cameraMaxX;
	private float cameraMaxY;
	private float cameraMinX;
	private float cameraMinY;


	// Start is called before the first frame update
	void Start()
    {
		Bounds bounds = OrthographicBounds(camera);
		edgeCollider2D = GetComponent<EdgeCollider2D>();
		cameraMaxX = bounds.max.x;
		cameraMaxY = bounds.max.y;
		cameraMinX = bounds.min.x;
		cameraMinY = bounds.min.y;

		Vector2[] points = edgeCollider2D.points;
		points[0] = new Vector2(cameraMinX, cameraMaxY);
		points[1] = new Vector2(cameraMaxX, cameraMaxY);
		points[2] = new Vector2(cameraMaxX, cameraMinY);
		points[3] = new Vector2(cameraMinX, cameraMinY);
		points[4] = new Vector2(cameraMinX, cameraMaxY);

		edgeCollider2D.points = points;
		
	}

	public Bounds OrthographicBounds(Cinemachine.CinemachineVirtualCamera camera)
	{
		float screenAspect = camera.m_Lens.Aspect * 2;
		float cameraHeight = camera.m_Lens.OrthographicSize * 2;
		Bounds bounds = new Bounds(
			camera.transform.position,
			new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
		return bounds;
	}

	private void LateUpdate()
	{
		edgeCollider2D.transform.position = camera.transform.position;
	}
}
