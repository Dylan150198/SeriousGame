using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OnHit : MonoBehaviour
{
    private GameLogic gameLogic; 
    // Start is called before the first frame update
    void Start()
    {
        gameLogic = GameObject.Find("GameManager").GetComponent<GameLogic>();
    }

    // Tell GameLogic that this target has been destroyed and the score needs to be incremented
    void OnMouseDown()
    {
        gameLogic.incrementScore(1);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
