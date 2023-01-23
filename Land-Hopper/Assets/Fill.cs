using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fill : MonoBehaviour
{
    public Vessel ScoreData;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ScoreData.Score += 1;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(3);
        }
    }
}
