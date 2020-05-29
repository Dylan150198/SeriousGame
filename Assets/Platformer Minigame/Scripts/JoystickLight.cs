using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickLight : MonoBehaviour
{

	public Transform light;
	public float speed = 4.0f;
	private bool touchStart = false;
	private Vector2 pointA;
	private Vector2 pointB;
	


	public Transform circle;
	//public Transform outercircle;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetMouseButtonDown(0)) {
			pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
			circle.transform.position = pointA * -1;
			//outercircle.transform.position = pointA * -1;
			circle.GetComponent<SpriteRenderer>().enabled = true;
			//outercircle.GetComponent<SpriteRenderer>().enabled = true;
		}
		if (Input.GetMouseButton(0))
		{
			touchStart = true;
			pointB = pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
		}
		else {
			touchStart = false;
		}
    }

	private void FixedUpdate()
	{
		if (touchStart)
		{
			Vector2 offset = pointB - pointA;
			Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
			MoveLight(direction * -1);

			circle.transform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y) * -1;
		}
		else {
			circle.GetComponent<SpriteRenderer>().enabled = false;
			//outercircle.GetComponent<SpriteRenderer>().enabled = false;
		}
	}

	void MoveLight(Vector2 direction) {
		light.Translate(direction * speed * Time.deltaTime);
	}
}
