using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{


	public UnityEvent onCoinPickUp;


    // Start is called before the first frame update
    void Start()
    {
        
    }

	
	private void OnTriggerEnter2D(Collider2D collision)
	{
		Destroy(gameObject);
		PlatformEventHandler.current.CoinPickUp();
	}
	// Update is called once per frame
	void Update()
    {
        
    }
}
