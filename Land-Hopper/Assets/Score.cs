using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text ScoreText;
    public int Kills;
    public int score;

    int NeededKills = 10;
    public GameObject ScenePortal;
    private void Start()
    {
        score = PlayerPrefs.GetInt("Score");
        ScoreText.text = score.ToString();
        Kills = PlayerPrefs.GetInt("Kills");
    }
    private void Update()
    {
        if (Kills > NeededKills)
        {
            ScenePortal.SetActive(true);
            NeededKills *= 2;
        }
    }
    public void ScoreIncrease()
    {
        score += 100;
        Kills++;
        ScoreText.text = score.ToString();
        
    }
}
