using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NicknameInputField : MonoBehaviour
{

    InputField inputField;
    public Text waitingText;
    public int secondLeft = 3;
    public bool takingAway = false;
    bool pressed_enter = false;

    void Start()
    {
        inputField = GetComponent<InputField>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            inputField.gameObject.SetActive(false);
            
            waitingText.gameObject.SetActive(true);
        }
    }
}
