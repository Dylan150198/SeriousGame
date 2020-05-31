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
        yield return new WaitForSeconds(sceneLoadTime);
        SceneManager.LoadScene(sceneName);
    }


    public void StartMotoringMaze()
    {

    }
}
