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

    // Tell scoremanager to add score to the combo
    public void addToCombo(int score)
    {
        scoreManager.updateCombo(score);
    }

    // Tell scoremanager to reset the combo
    public void resetCombo()
    {
        scoreManager.resetCombo();
    }

    // Tell scoremanager to add a miss
    public void addMiss()
    {
        scoreManager.addMiss(1);
    }
}
