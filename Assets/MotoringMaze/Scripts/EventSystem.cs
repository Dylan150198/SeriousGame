using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
    public static EventSystem current;

    void Awake()
    {
        current = this;
    }

    public event Action OnPlayerHit;
    public event Action<GameState> OnGameStateChanged;

    public void PlayerHit()
    {
        OnPlayerHit?.Invoke();
    }

    public void GameStateChanged(GameState state)
    {
        OnGameStateChanged?.Invoke(state);
    }

}
