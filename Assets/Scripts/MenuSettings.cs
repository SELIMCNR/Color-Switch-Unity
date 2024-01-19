using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuSettings : MonoBehaviour
{
    public AudioMixer audioMixer;

    Resolution[] resoulutions  ;

    public Dropdown resolutionDropdown;


     void Start()
    {
        resoulutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resoulutions.Length; i++)
        {
            string option = resoulutions[i].width + " x " + resoulutions[i].height;
            options.Add(option);

            if (resoulutions[i].width == Screen.currentResolution.width &&
               resoulutions[i].height == Screen.currentResolution.height )
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resoulutions[resolutionIndex];
        Screen.SetResolution(resolution.width,resolution.height,Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetQuality(int quailtyIndex)
    {
        QualitySettings.SetQualityLevel(quailtyIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
