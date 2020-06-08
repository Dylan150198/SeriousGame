﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCoordinator : MonoBehaviour
{
    public Level[] levels;
    public Level currentLevel;
    public SpriteRenderer spriteRenderer;
    public Button correctBtn;
    public GameObject switchPanel;
    public GameObject finishPanel;
    public GameObject losePanel;
    public Text scoreText;
    public int currentSubLevelIndex = 0;

    // Correct button location, based on current sprite
    public int[] correctXPos;
    public int[] correctYPos;
    public int[] correctWidth;
    public int[] correctHeight;

    void Start()
    {
        switchPanel.SetActive(false);
        finishPanel.SetActive(false);
        losePanel.SetActive(false);
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

        LoadSubLevel();

    }

    public void ChangeToNextSubLevel()
    {
        if(currentSubLevelIndex < currentLevel.subLevels.Length - 1)
        {
            spriteRenderer.sprite = currentLevel.currentSubLevel.background;
            currentSubLevelIndex += 1;
            scoreText.text = "Score : " + currentSubLevelIndex.ToString();
            Debug.Log(currentSubLevelIndex);
            StartCoroutine(SubLevelSwitch());
        }
        else
        {
            scoreText.text = "Score : " + currentSubLevelIndex.ToString();
            finishPanel.SetActive(true);
            spriteRenderer.sprite = currentLevel.currentSubLevel.background;
            Debug.Log("Game Over you won :)");
        }
    }

    public void GameLost()
    {
        losePanel.SetActive(true);
        Debug.Log("Game Over you lost :(");
    }

    public void LoadSubLevel()
    {        
        // Set the settings of the current level
        currentLevel.setCurrentSublevel(currentSubLevelIndex);

        // Set the background sprite to the background of the firstlevel
        spriteRenderer.sprite = currentLevel.currentSubLevel.blurredBackground;

        // Set the correct button location based on the current levels sublevel
        correctBtn.transform.localPosition = new Vector3(currentLevel.currentSubLevel.correctBtnXPos, currentLevel.currentSubLevel.correctBtnYPos);
        correctBtn.GetComponent<RectTransform>().sizeDelta = new Vector2(currentLevel.currentSubLevel.correctBtnWidth, currentLevel.currentSubLevel.correctBtnHeight);
    }

    private IEnumerator SubLevelSwitch()
    {       
        switchPanel.SetActive(true);

        // Fake loading time
        yield return new WaitForSeconds(3);

        switchPanel.SetActive(false);

        LoadSubLevel();

        yield return null;
    }


    // Update is called once per frame
    void Update()
    {

    }

}