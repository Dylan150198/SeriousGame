using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCoordinator : MonoBehaviour
{
    public Level[] levels;
    public Level currentLevel;
    public SpriteRenderer spriteRenderer;
    public Button correctBtn;

    public int currentSprite = 0;

    // Correct button location, based on current sprite
    public int[] correctXPos;
    public int[] correctYPos;
    public int[] correctWidth;
    public int[] correctHeight;

    void Start()
    {
        //correctXPos = new int[] { 71, -196, 5, -60, 355 };
        //correctYPos = new int[] { -730, -370, -667, -926, 267 };
        //correctWidth = new int[] { 378, 208, 1070, 885, 301 };
        //correctHeight = new int[] { 387, 209, 679, 107, 105 };

        //spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        correctBtn = GameObject.Find("SceneBolCorrectBtn").GetComponent<Button>();

        // Pick a random level
        float rnd = Random.Range(0, levels.Length - 1);
        for (int i = 0; i < levels.Length; i++)
        {
            if(rnd == i)
            {
                currentLevel = levels[i];
                Debug.Log("Current Level = " + i);
            }
        }

        // Set the settings of the current level
        currentLevel.setCurrentSublevel(0);

        // Set the background sprite to the background of the firstlevel
        spriteRenderer.sprite = currentLevel.currentSubLevel.background;
    }

    public void ChangeToNextSprite()
    {
        try
        {
            int newSprite = currentSprite + 1;
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

    // Update is called once per frame
    void Update()
    {

    }

    void TaskOnClick()
    {

    }
}
