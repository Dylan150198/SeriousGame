using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score;
    public TMP_Text scoreText;
    private int combo;
    public TMP_Text comboText;
    private int misses;
    public TMP_Text missesText;

    public void addScore(int score)
    {
        this.score += score;
        scoreText.text = "Score: " + this.score.ToString();
    }

    public void updateCombo(int combo)
    {
        this.combo += combo;
        comboText.text = "Combo: " + this.combo.ToString();
    }

    public void resetCombo()
    {
        this.combo = 0;
        comboText.text = "Combo: " + this.combo.ToString();
    }

    public void addMiss(int miss)
    {
        this.misses += miss;
        missesText.text = "Misses: " + this.misses.ToString();
    }

}
