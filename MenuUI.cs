using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    /// On play button load "Game"
    public void OnPlayButton()
    {
        SceneManager.LoadScene("Game");
    }

    /// On Quit Button quit application/ Game
    public void OnQuitButton()
    {
        Application.Quit();
    }
}