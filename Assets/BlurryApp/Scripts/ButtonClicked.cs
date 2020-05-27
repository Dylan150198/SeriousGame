using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonClicked : MonoBehaviour
{
    public Sprite[] spriteArray;
    public SpriteRenderer spriteRenderer;
    public Button correctBtn;
    public int currentSprite = 0;

    // Correct button location, based on current sprite
    public int[] correctXPos;
    public int[] correctYPos;
    public int[] correctWidth;
    public int[] correctHeight;

    public void ChangeToNextSprite()
    {
        try
        {
            int newSprite = currentSprite + 1;
            spriteRenderer.sprite = spriteArray[newSprite];
            currentSprite = newSprite;
            correctBtn.transform.localPosition = new Vector3(correctXPos[newSprite], correctYPos[newSprite]);
            correctBtn.GetComponent<RectTransform>().sizeDelta = new Vector2(correctWidth[newSprite], correctHeight[newSprite]);
            Debug.Log(correctBtn.transform.position);
            Debug.Log(correctBtn.GetComponent<RectTransform>().sizeDelta);
        }
        catch (System.Exception e)
        {
            Debug.LogException(e);
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
        correctBtn = GameObject.Find("SceneBolCorrectBtn").GetComponent<Button>();
        correctXPos = new int[] { 71, -196, 5, -60, 355 };
        correctYPos = new int[] { -730, -370, -667, -926, 267 };
        correctWidth = new int[] { 378, 208, 1070, 885, 301 };
        correctHeight = new int[] { 387, 209, 679, 107, 105 };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {

    }
}
