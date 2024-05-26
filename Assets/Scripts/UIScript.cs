using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreUI;
    [SerializeField] TextMeshProUGUI enemiesUI;

    GameController gameController;

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
    void Update()
    {
        scoreUI.text = gameController.score.ToString();
        enemiesUI.text = gameController.enemiesRemaining.ToString();
    }
}
