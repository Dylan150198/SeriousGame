using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnHit : MonoBehaviour
{
    public int score;
    public Text scoreDisplay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMouseDown()
    {
        score++;
        scoreDisplay.text = score.ToString();
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
