using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Begin,
    Play,
    GameEnd,
    Win,
    Lose
}

public static partial class GameStateEvent
{
    public static event System.Action<GameState> OnChangeGameState;
    public static void Fire_OnChangeGameState(GameState gameState) { OnChangeGameState?.Invoke(gameState); }

    public static event System.Action OnBeginGame;
    public static void Fire_OnBeginGame() { OnBeginGame?.Invoke(); }

    public static event System.Action OnPlayGame;
    public static void Fire_OnPlayGame() { OnPlayGame?.Invoke(); }

    public static event System.Action OnEndGame;
    public static void Fire_OnEndGame() { OnEndGame?.Invoke(); }
}



public class GameManager : MonoSingleton<GameManager>
{
    public GameState gameState;

    protected override void Awake()
    {
        base.Awake();
        GameStateEvent.OnChangeGameState += OnChangeGameState;
    }

    private void Start()
    {
        OnChangeGameState(GameState.Begin);
    }

    void OnChangeGameState(GameState newState)
    {
        gameState = newState;

        switch (newState)
        {
            case GameState.Begin:
                HandleBegin();
                break;

            case GameState.Play:
                HandlePlay();
                break;

            case GameState.GameEnd:
                HandleGameEnd();
                break;

            

            default:
                break;
        }
        
    }



    public void HandleBegin()
    {

        GameStateEvent.Fire_OnBeginGame();
    }

    public void HandlePlay()
    {
        GameStateEvent.Fire_OnPlayGame();
    }

    public void HandleGameEnd()
    {
        GameStateEvent.Fire_OnEndGame();
    }

    private void OnDisable()
    {
        GameStateEvent.OnChangeGameState -= OnChangeGameState;
    }
}