using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text ScoreText;
    public Vessel SO;

    public GameObject ScenePortal;
    private void Start()
    {

    }
    private void Update()
    {
        if (SO.Kills >= SO.NeededKills)
        {
            ScenePortal.SetActive(true);
            SO.NeededKills += 10;
        }
    }
    public void ScoreIncrease()
    {
        SO.Score += 100;
        SO.Kills++;
        ScoreText.text = SO.Score.ToString();
        
    }
}
