using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectLocationClicked : MonoBehaviour
{
    public Sprite[] spriteArray;
    public SpriteRenderer spriteRenderer;

    public void ChangeSprite()
    {
        spriteRenderer.sprite = spriteArray[4];
        Debug.Log("Button Clicked");
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {

    }
}
