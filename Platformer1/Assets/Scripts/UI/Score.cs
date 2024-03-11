using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int score = 0;
    public Text scoreText;
    [SerializeField] GameObject gameManager;
    private GameController gameControllerScript;


    private void Start()
    {
        gameControllerScript = gameManager.GetComponent<GameController>();
        score = 0;
    }

    private void Update()
    {
        if (!gameControllerScript.CheckGameOver())
        {
            scoreText.text = ("Score: " + score.ToString() + "  Pts.");
        }
    }

    public void UpdateScore(int _newPoints)
    {
        score += _newPoints;
    }

    public int CheckScore()
    {
        return score;
    }
}
