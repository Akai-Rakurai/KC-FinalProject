using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class puasemenu : MonoBehaviour
{
    public static bool IsGamePuased = false;
    public GameObject PauseUi;
    public Vessel SO;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(IsGamePuased)
            {
                Resume();
            }
            else
            {
                pause();
            }
        }
    }
    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        PauseUi.SetActive(false);
        Time.timeScale = 1f;
        IsGamePuased = false;
    }

    public void pause()
    {
        Cursor.lockState = CursorLockMode.None;
        PauseUi.SetActive(true);
        Time.timeScale = 0f;
        IsGamePuased = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
        print("Quit");
        SO.SetData();
    }
}
