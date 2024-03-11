using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BlastZone : MonoBehaviour
{

    [SerializeField] GameObject gameManager;
    private GameController gameControllerScript;
    private BoxCollider2D boxCollider;


    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        gameControllerScript = gameManager.GetComponent<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameControllerScript.GameOverCall();
        }
    }
}
