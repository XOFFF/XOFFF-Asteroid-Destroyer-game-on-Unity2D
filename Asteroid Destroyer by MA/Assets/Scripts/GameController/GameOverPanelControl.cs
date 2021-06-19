using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanelControl : MonoBehaviour
{
    public void PlayAgain()
    {
        int gameSceneID = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(gameSceneID);
    }

    public void MenuScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}