using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    // Start is called before the first frame update
    public GameState State;
    public static event Action<GameState> OnGameStateChanged;
    public int enemiesAlive = 0;
    void Awake()
    {
        Instance=this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.StartGame:
                break;
            case GameState.CheckCondition:
                HandleCheckCondition();
                break;
            case GameState.Victory:
                break;
            case GameState.Lose:
                break;
        }
        OnGameStateChanged?.Invoke(newState);
    }

    private void HandleCheckCondition()
    {
        var enemies = FindObjectOfType<EnemyHealthScript>();

        if (enemiesAlive<1) { UpdateGameState(GameState.Victory); }
        //if (!enemies.Any(u=>)
    }

    public enum GameState 
    {
        StartGame,Victory,Lose,CheckCondition
    }

    public void UpdateEnemiesAlive(bool alive) 
    {
        if (alive) enemiesAlive = enemiesAlive + 1; 
        else enemiesAlive = enemiesAlive - 1;
    }
}
