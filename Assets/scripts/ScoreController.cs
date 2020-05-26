﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hintUsedText;
    public int penaltyScorePerMove;
    public int penaltyScorePerSecond;
    public int penaltyScoreForHint;
    public int hintLastsSeconds;
    public int hintAfterSeconds;
    private int _score = 0;
    private float _timeInCurrentMove = 0;
    private float _timeElapsedSinceLastReset = 0;
    private bool _hintInUse = false;
    private float _timeHintActive = 0;
    public Material redPiece;
    public Material bluePiece;
    public Color redPieceDefaultColor;
    public Color bluePieceDefaultColor;
    public Color ColorBlindColor;

    void Start()
    {
        HidePieceMaterialColors();
        hintUsedText.text = "Hint used! (+" + penaltyScoreForHint + " penalty)";
        DisplayHintUsedLabel(false);
    }

    void Update()
    {
        _timeInCurrentMove += Time.deltaTime;
        _timeElapsedSinceLastReset += Time.deltaTime;
        if (_timeElapsedSinceLastReset > 1)
        {
            float timeScore = _timeElapsedSinceLastReset * penaltyScorePerSecond;
            _score += Mathf.CeilToInt(timeScore);
            _timeElapsedSinceLastReset = 0;
            UpdateScore();
        }
        if (_timeInCurrentMove > hintAfterSeconds && !_hintInUse && _timeHintActive == 0f)
        {
            HintUsed();
        }

        if (_hintInUse)
        {
            _timeHintActive += Time.deltaTime;
            if (_timeHintActive >= hintLastsSeconds)
            {
                DeactivateHint();
            }
        }
    }

    public void PlayTurn()
    {
        _score += penaltyScorePerMove;
        UpdateScore();
        DeactivateHint();
        _timeHintActive = 0;
        _timeInCurrentMove = 0;
    }

    private void UpdateScore()
    {
        scoreText.text = "Penalty Score: " + _score;
    }

    private void DisplayHintUsedLabel(bool show)
    {
        hintUsedText.enabled = show;
    }

    private void HintUsed()
    {
        _hintInUse = true;
        _score += penaltyScoreForHint;
        UpdateScore();
        ShowPieceMaterialColors();
        DisplayHintUsedLabel(true);
    }

    private void DeactivateHint()
    {
        _hintInUse = false;
        HidePieceMaterialColors();
        DisplayHintUsedLabel(false);
    }

    private void HidePieceMaterialColors()
    {
        redPiece.color = ColorBlindColor;
        bluePiece.color = ColorBlindColor;
    }

    private void ShowPieceMaterialColors()
    {
        redPiece.color = redPieceDefaultColor;
        bluePiece.color = bluePieceDefaultColor;
    }
}