using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NicknameInputField : MonoBehaviour
{

    InputField inputField;
    public int secondLeft = 3;
    public bool takingAway = false;
    bool pressed_enter = false;
    public Button _1vs1Button;
    public Button _2vs2Button;

    void Start()
    {
        inputField = GetComponent<InputField>();
        _1vs1Button.gameObject.SetActive(false);
        _2vs2Button.gameObject.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            inputField.gameObject.SetActive(false);
            _1vs1Button.gameObject.SetActive(true);
            _2vs2Button.gameObject.SetActive(true);

        }
    }
}
