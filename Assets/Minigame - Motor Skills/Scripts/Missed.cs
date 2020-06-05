using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missed : MonoBehaviour
{
    //public AudioClip m
    //private float initializationTime = 1;
    private GameLogic gameLogic;
    public GameObject effect;

    private void Start()
    {
        gameLogic = GameObject.Find("GameManager").GetComponent<GameLogic>();

        StartCoroutine(MissTimer(() =>
        {
            gameLogic.resetCombo();
            gameLogic.addMiss();
        }));
    }

    private IEnumerator MissTimer(Action action)
    {
        yield return new WaitForSeconds(0.95f);
        action();
    }

   

    //void Update()
    //{
    //    initializationTime -= 0.0001f;

    //    if (initializationTime > 0)
    //    {
    //        gameLogic.resetCombo();
    //    }
    //}
}
    