using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ButtonScripts : MonoBehaviour
{
    public Vessel SO;

    public AudioMixer audioMixer;

    Resolution[] resolutions;
    public Dropdown resolution;
    public Dropdown Quality;

    public void Start()
    {
        Cursor.lockState= CursorLockMode.None;
        resolutions = Screen.resolutions;

        resolution.ClearOptions();

        List<string> options = new List<string>();

        int currentresolutionindex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentresolutionindex = i;
            }
        }

        resolution.AddOptions(options);
        resolution.value = currentresolutionindex;
        resolution.RefreshShownValue();

        Quality.value = 4;
    }
    public void StartGame()
    {
        SO.SetData();
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        print("Quit");
        SO.SetData();
        Application.Quit();
    }
    public void VolumeSlider(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
    public void SetQuality(int QualityIndex)
    {
        QualitySettings.SetQualityLevel(QualityIndex);

    }
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
