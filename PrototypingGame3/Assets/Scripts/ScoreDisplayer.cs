using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreDisplayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            Transform panel = transform.GetChild(i);
            for(int j = 1; j < panel.childCount; j++)
            {
                if(j <= ScoreManager.scores[i].Count)
                {
                    panel.GetChild(j).GetComponent<TextMeshProUGUI>().text = ScoreManager.scores[i][j - 1].ToString();
                                
                }
                else
                {
                    panel.GetChild(j).GetComponent<TextMeshProUGUI>().text = "";
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Back()
    {
        SceneManager.LoadScene("Level Select");
    }
}
