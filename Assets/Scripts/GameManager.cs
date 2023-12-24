using System;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int highScoresCount;
    public HighScores highScores;
    public string playerName;
    public int playerScore;

    private void Awake()
    {
        if (instance != null)
        {
            LoadHighScores();
            Destroy(instance);
            return;
        }

        instance = this;
        highScores = new HighScores();
        highScores.highScoreList = new HighScore[highScoresCount];
        LoadHighScores();
        DontDestroyOnLoad(gameObject);
    }

    public void SaveHighScore()
    {
        HighScore player = new HighScore(playerName, playerScore);

        for (int i = 0; i < highScoresCount; ++i)
        {
            if (highScores.highScoreList[i] == null || player.score > highScores.highScoreList[i].score)
            {
                HighScore temp = highScores.highScoreList[i];
                highScores.highScoreList[i] = player;
                player = temp;
            }
        }

        string path = Application.persistentDataPath + "/savefile.json";
        string json = JsonUtility.ToJson(highScores);
        File.WriteAllText(path, json);
    }

    public void LoadHighScores()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            highScores = JsonUtility.FromJson<HighScores>(json);
        }
    }
}

[Serializable]
public class HighScores
{
    public HighScore[] highScoreList;
}

[Serializable]
public class HighScore
{
    public string name;
    public int score;

    public HighScore(string name, int score)
    {
        this.name = name;
        this.score = score;
    }
}
