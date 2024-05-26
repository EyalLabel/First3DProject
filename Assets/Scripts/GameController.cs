using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] MainMenuScript mainMenuScript;
    public int score { get; private set; }
    public int enemiesRemaining { get; private set; }

    
    public void EnemyKilled() 
    {
        score = score + 50;
        enemiesRemaining = enemiesRemaining - 1;

        if (enemiesRemaining <= 0) mainMenuScript.GoToWin();
       // Debug.Log(score+" "+ enemiesRemaining);
    }

    public void EnemySpawned()
    {
        
        enemiesRemaining++;
    }

    public void PlayerKilled() 
    {
        mainMenuScript.GoToLose();
    }
}
