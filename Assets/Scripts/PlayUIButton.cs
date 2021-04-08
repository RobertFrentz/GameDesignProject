using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayUIButton : MonoBehaviour
{
    Button playButton;
    
    GameObject waitingText;
    GameObject playContainer;
    public Button _1vs1Button;
    public Button _2vs2Button;
    public Button backButton;
    public GameObject nickNameField;
    public Button settingsButton;
    public GameObject settingsContainer;

    void Start()
    {
        playButton = GetComponent<Button>();
        waitingText = GameObject.Find("WaitingText");
        playContainer = GameObject.Find("PlayContainer");

        waitingText.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
        _1vs1Button.gameObject.SetActive(false);
        _2vs2Button.gameObject.SetActive(false);
        nickNameField.gameObject.SetActive(false);
        playButton.onClick.AddListener(() => ButtonClicked());
        settingsButton.onClick.AddListener(() => ChangeCanvas());
    }

    
    void ButtonClicked()
    {
        playContainer.SetActive(false);
        nickNameField.gameObject.SetActive(true);
    }
    void ChangeCanvas()
    {
        settingsContainer.SetActive(true);
        backButton.gameObject.SetActive(true);
        int numberOfChildren = settingsContainer.transform.childCount;
        for (int i = 0; i < numberOfChildren; i++)
        {
            playContainer.transform.GetChild(i).gameObject.SetActive(true);
        }

    }
}
