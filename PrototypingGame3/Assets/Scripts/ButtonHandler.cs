using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void LoadLevelOne()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LoadLevelTwo()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void LoadLevelThree()
    {
        SceneManager.LoadScene("Level 3");
    }


    public void LoadHighScoreLevel()
    {
        SceneManager.LoadScene("HighScores");
    }

}
