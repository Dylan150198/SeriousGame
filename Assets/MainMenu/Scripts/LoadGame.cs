﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    public void OnLoadGameClicked()
    {
        SceneManager.LoadScene("MotoringMazeMenu");
    }
}