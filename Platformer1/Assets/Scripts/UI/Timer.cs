using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float maxRoundTime;
    [SerializeField] GameObject gameManager;
    private GameController gameControllerScript;
    private float currRoundTime;
    public Text timeText;

    private void Start()
    {
        currRoundTime = maxRoundTime;
        gameControllerScript = gameManager.GetComponent<GameController>();
    }

    private void Update()
    {
        if (!gameControllerScript.CheckGameOver())
        {
            currRoundTime -= Time.deltaTime;
            timeText.text = ("Time: " + currRoundTime.ToString("0"));

            if (currRoundTime <= 0)
            {
                gameControllerScript.YouWinCall();
            }
        }
    }
}
