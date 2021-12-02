using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int scoreToWin;
    public int curScore;
    public bool gamePaused; 
    
    public static GameManager instance; 

    void Awake()
    {
        // Set the instance to this script
        instance = this; 
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            TogglePauseGame();
        }
    }

    public void TogglePauseGame()
{
    // setting up a toggle switch for pause menu
    gamePaused = !gamePaused;
    Time.timeScale = gamePaused == rue ? 0.0f : 1.0f

    // toggle pause menu & Cursor 
    GameUI.Instance.TogglePauseMenu(gamePaused);
    Cursor.lockState = gamePaused == true ? CursorLockMode.None : CursorLockMode.Locked;
} 
     public void AddScore(int score)
     {
         curScore += score;

         ///Update score text
         GameUI.instance.UpdateScoreText(curScore);

        ///Do you have enough points to win
          if(curScore >= scoreToWin)
            WinGame();
     }

     void WinGame()
     {
         /// Show Win screen
         GameUI.instance.SetEndGameScreen(true, curScore);
     }

     public void LoseGame()
     {
         //Load and set end game screen
         GameUI.instance.SetEndGameScreen(false, curScore)
         Time.timeScale = 0.0f; 
         gamePaused = true; 

     }
}
