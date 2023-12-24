using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI[] highScoreTexts;
    public TextMeshProUGUI playerNameText;

    private void Start()
    {
        for (int i = 0; i < GameManager.instance.highScoresCount; ++i)
        {
            if (GameManager.instance.highScores.highScoreList[i] != null)
            {
                string name = GameManager.instance.highScores.highScoreList[i].name;
                int score = GameManager.instance.highScores.highScoreList[i].score;
                highScoreTexts[i].text = name + ": " + score;
            }
        }
    }

    public void PlayGame()
    {
        GameManager.instance.playerName = playerNameText.text;
        SceneManager.LoadScene("main");
    }
}
