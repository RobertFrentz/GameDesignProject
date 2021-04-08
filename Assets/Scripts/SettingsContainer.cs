using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsContainer : MonoBehaviour
{
    GameObject settingsContainer;
    public AudioMixer audioMixer;
    public Button backButton;
    void Start()
    {
        settingsContainer = GameObject.Find("SettingsContainer");
        settingsContainer.SetActive(false);
        backButton.onClick.AddListener(() => ChangeCanvas());
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void ChangeCanvas()
    {
        settingsContainer.SetActive(false);
        backButton.gameObject.SetActive(false);
        GameObject playContainer = GameObject.Find("PlayContainer");
        int numberOfChildren = playContainer.transform.childCount;
        for (int i = 0; i < numberOfChildren; i++)
        {
            playContainer.transform.GetChild(i).gameObject.SetActive(true);
        }
            
    }
}
