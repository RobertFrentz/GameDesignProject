using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayUIButton : MonoBehaviour
{
    Button buttonToHide;
    GameObject nickNameField;
    GameObject waitingText;
    GameObject playContainer;
    public Button _1vs1Button;
    public Button _2vs2Button;
    void Start()
    {
        buttonToHide = GetComponent<Button>();
        nickNameField = GameObject.Find("NicknameField");
        waitingText = GameObject.Find("WaitingText");
        playContainer = GameObject.Find("PlayContainer");

        waitingText.gameObject.SetActive(false);
        _1vs1Button.gameObject.SetActive(false);
        _2vs2Button.gameObject.SetActive(false);
        nickNameField.gameObject.SetActive(false);
        buttonToHide.onClick.AddListener(() => ButtonClicked());
    }

    
    void ButtonClicked()
    {
        playContainer.SetActive(false);
        //GameObject backButton = GameObject.Find("BackButton");
        //backButton.gameObject.SetActive(true);
        nickNameField.gameObject.SetActive(true);
    }
}
