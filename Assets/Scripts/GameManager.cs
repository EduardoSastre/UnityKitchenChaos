using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager gameManager;

    public event EventHandler OnStateChanged;

    private enum State { 
        WaitingToStart,
        CountdownToStart,
        GamePlaying,
        GameOver
    }

    private State state;
    private float waitingToStartTimer = 1f;
    private float countdownToStartTimer = 3f;
    private float gamePlayingTimerMax = 60f;
    private float gamePlayingTimer;

    private void Awake()
    {
        state = State.WaitingToStart;
        gameManager = this;
        gamePlayingTimer = gamePlayingTimerMax;
    }

    private void Update(){

        UpdateState();
    }

    private void UpdateState() { 
    
        switch (state)
        {
            case State.WaitingToStart:
                waitingToStartTimer -= Time.deltaTime;
                if (waitingToStartTimer < 0f) {
                    state = State.CountdownToStart;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.CountdownToStart:
                countdownToStartTimer -= Time.deltaTime;
                if (countdownToStartTimer < 0f)
                {
                    state = State.GamePlaying;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.GamePlaying:
                gamePlayingTimer -= Time.deltaTime;
                if (gamePlayingTimer < 0f)
                {
                    state = State.GameOver;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.GameOver:
                break;
        }

        Debug.Log(state);
    }

    public static GameManager GetInstance() { 
        return gameManager;
    }

    public bool canPlay() {
        return state == State.GamePlaying;
    }

    public bool IsCountdownToStartActive() { 
        return state == State.CountdownToStart;
    }

    public float GetCountdownToStartTimer() { 
        return countdownToStartTimer;
    }

    public bool IsGameOver() {
        return state == State.GameOver;
    }

    public float GetGamePlayingTimerNormalized() {
        return gamePlayingTimer/gamePlayingTimerMax;
    }
}
