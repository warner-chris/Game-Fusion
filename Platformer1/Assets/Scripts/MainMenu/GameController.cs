using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameOver gameOverScreen;
    public YouWin youWinScreen;
    private bool gameOver = false;

    public void YouWinCall()
    {
        if (!gameOver)
        {
            youWinScreen.SetActive();
            gameOver = true;
        }
    }

    public void GameOverCall()
    {
        if (!gameOver)
        {
            gameOverScreen.SetActive();
            gameOver = true;
        }
    }

    public bool CheckGameOver()
    {
        return gameOver;
    }
}
