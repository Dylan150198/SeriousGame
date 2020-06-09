using Project.Global;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameCoordinator : MonoBehaviour
{
    public Level[] levels;
    public Level currentLevel;
    public SpriteRenderer spriteRenderer;
    public Button correctBtn;
    public Text scoreText;
    public Text introText;
    public int currentSubLevelIndex = 0;

    // Panels
    public GameObject switchPanel;
    public GameObject finishPanel;
    public GameObject losePanel;
    public GameObject introPanel;

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

        introText.text = currentLevel.objectiveText;
        StartCoroutine(PlayIntro());

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
            WsClient.instance.SendScore(MinigameState.BLURRY, currentSubLevelIndex + 1);
            MinigameStateHandler.instance.LoadIntermission();
        }
    }

    public void GameLost()
    {
        int result;
        int.TryParse(scoreText.text, out result);
        losePanel.SetActive(true);
        Debug.Log("Game Over you lost :(");
        WsClient.instance.SendScore(MinigameState.BLURRY, currentSubLevelIndex + 1);
        MinigameStateHandler.instance.LoadIntermission();
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

    private IEnumerator PlayIntro()
    {
        introPanel.SetActive(true);

        // Fake loading time
        yield return new WaitForSeconds(3);

        introPanel.SetActive(false);

        yield return null;
    }


    // Update is called once per frame
    void Update()
    {

    }

}
