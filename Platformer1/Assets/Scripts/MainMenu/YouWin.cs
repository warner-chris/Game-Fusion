using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWin : MonoBehaviour
{
    public void SetActive()
    {
        gameObject.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
