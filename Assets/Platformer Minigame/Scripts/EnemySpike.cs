using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpike : MonoBehaviour
{

	private void OnTriggerEnter2D(Collider2D other)
	{
        PlatformEventHandler.current.EnemyHit();
    }
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
