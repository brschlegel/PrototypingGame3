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
    public PlayerController player;
    public Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        
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
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        timeText.text = timer.ReturnTime();
        winCanvas.gameObject.SetActive(true);
    }

}
