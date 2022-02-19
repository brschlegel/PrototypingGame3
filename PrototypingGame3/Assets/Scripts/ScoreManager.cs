using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public static class ScoreManager
{
    public static List<List<float>> scores = new List<List<float>>();
    static int numLevels = 3;

    public static void LoadHighscores()
    {
        //Clearing so I dont have to deal with any issues with holdovers in the editor
        scores.Clear();
        for(int i = 0; i < numLevels; i++)
        {
            scores.Add(new List<float>());
            string fileName = "HighScores/LevelHighScore" + i + ".txt";
            if (!File.Exists(fileName))
            {
                File.CreateText(fileName);
            }
            else
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string ln;
                    while ((ln = sr.ReadLine()) != null)
                    {
                        scores[i].Add(float.Parse(ln));
                    }
                }
            }
        }
    }

    public static float GetHighScore(int levelIndex)
    {
        if (scores[levelIndex].Count > 0)
        {
            return scores[levelIndex][0];
        }
        else
            return 30;
    }

    public static bool RecordScore(float score, int levelIndex)
    {
        scores[levelIndex].Add(score);
        if(scores[levelIndex].Count == 1)
        {
            return true;
        }
        scores[levelIndex].Sort();
        if(scores[levelIndex].Count > 3)
        {
            scores[levelIndex] = scores[levelIndex].GetRange(0, 3);
        }
        return score == scores[levelIndex][0];
        
    }

    public static void WriteScores()
    {
        for (int i = 0; i < numLevels; i++)
        {
            string fileName = "HighScores/LevelHighScore" + i + ".txt";

            using (StreamWriter sr = new StreamWriter(fileName))
            {
                foreach(float f in scores[i])
                {
                    sr.WriteLine(f);
                }
            }

        }
    }
     
}
