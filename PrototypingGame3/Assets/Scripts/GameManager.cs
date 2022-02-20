using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TarodevController;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Canvas winCanvas;
    public Timer timer;
    public Text timeText;
    public Text highScore;

    // Start is called before the first frame update
    void Start()
    {
        highScore.text = (ScoreManager.GetHighScore(SceneManager.GetActiveScene().buildIndex - 1)).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Stops timer and brings up win Canvas
    public void EndLevel()
    {
        
        timer.StopTimer();
        if(ScoreManager.RecordScore(timer.timeElapsed, SceneManager.GetActiveScene().buildIndex - 1))
        {
            //If we are here u have a new highscore
            Debug.Log("HighScore");
        }
        timeText.text = timer.ReturnTime();
        winCanvas.gameObject.SetActive(true);
    }

    private void OnApplicationQuit()
    {
        ScoreManager.WriteScores();
    }
}
