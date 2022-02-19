using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ScoreManager.LoadHighscores();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnApplicationQuit()
    {
        ScoreManager.WriteScores();
    }
}
