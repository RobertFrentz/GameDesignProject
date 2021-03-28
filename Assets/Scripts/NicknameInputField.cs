using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NicknameInputField : MonoBehaviour
{

    InputField inputField;
    Graphic placeholder;
    Text inputText;
    void Start()
    {
        inputField = GetComponent<InputField>();
        placeholder = inputField.placeholder;
        inputText = GameObject.FindObjectsOfType<Text>()[0];
    }
    void Update() {

        
        
    }
    void OnGUI()
    { 
        if (Event.current.isKey && Event.current.type == EventType.KeyDown)
        {
            ((Text)placeholder).text = "";
            if (Event.current.keyCode.ToString() != "None")
            {
                inputText.text += Event.current.keyCode.ToString();
                Debug.Log(Event.current.keyCode);
            }
            
        }
    }
}
