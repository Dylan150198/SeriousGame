using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public int sceneLoadTime;
    public GameObject loadingPanel;

    private void Start()
    {
        loadingPanel.SetActive(false);
    }

    public void StartScene(string sceneName)
    {
        StartCoroutine(LoadScene(sceneName));
    }

    private IEnumerator LoadScene(string sceneName)
    {
        loadingPanel.SetActive(true);

        // Fake loading time
        yield return new WaitForSeconds(sceneLoadTime);
        
        // True loading operation
        AsyncOperation asyncOp = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncOp.isDone)
        {
            // Play spritesheet loading animation or/and show instructions
            Debug.Log("Waiting");

            // This finishes the async operation
            yield return null;
        }
    }


    public void StartMotoringMaze()
    {

    }
}
