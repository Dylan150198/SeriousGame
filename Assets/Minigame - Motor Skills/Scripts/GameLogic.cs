using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public Score scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Tell scoremanager to increment the score
    public void incrementScore(int score)
    {
        scoreManager.addScore(score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
