using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour
{
    Button myButton;
    public GameObject settingsContainer;
    void Start()
    {
        myButton = GameObject.Find("SettingsButton").GetComponent<Button>();
        myButton.onClick.AddListener(() => { HideButtons(); });
    }
    void HideButtons()
    {
        Button[] all_objects = GameObject.FindObjectsOfType<Button>();
        foreach (Button b in all_objects)
        {
            if (b.name == "PlayButton" || b.name == "ExitButton" || b.name == "SettingsButton")
            {
                b.gameObject.SetActive(false);
            }

        }
        settingsContainer.SetActive(true);
    }
}
