using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonClicked : MonoBehaviour
{
    public Sprite[] spriteArray;
    public SpriteRenderer spriteRenderer;
    public Button button;
    public int currentSprite = 0;

    public void ChangeToNextSprite()
    {
        try
        {
            spriteRenderer.sprite = spriteArray[currentSprite + 1];
            currentSprite = currentSprite + 1;
        }
        catch (System.Exception)
        {
            Debug.Log("Game Over you won :)");
        }
        Debug.Log("Button Clicked");
    }

    public void WrongLocationMessage()
    {
        Debug.Log("Oops.. Je bent verdwaald!");
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
