using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour
{
	private void OnTriggerExit2D(Collider2D collision)
	{
		float collisionY = collision.gameObject.transform.position.y;
		float currentY = gameObject.transform.position.y;

		if (collisionY > currentY)
		{
			EventSystem.current.GameStateChanged(GameState.STOPPED);
		}
	}
}
