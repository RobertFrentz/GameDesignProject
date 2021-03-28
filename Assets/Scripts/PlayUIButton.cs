using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayUIButton : MonoBehaviour
{
    Button buttonToHide;
    InputField nickNameField;
    void Start()
    {
        buttonToHide = GetComponent<Button>();
        nickNameField = GameObject.FindObjectsOfType<InputField>()[0];
        Button[] all_Objs = GameObject.FindObjectsOfType<Button>();
        
        nickNameField.gameObject.SetActive(false);
        buttonToHide.onClick.AddListener(() => ButtonClicked(all_Objs));
    }


    void ButtonClicked(Button[]  all_objects)
    {
        foreach(Button b in all_objects)
        {
            if(b.name == "PlayButton" || b.name == "ExitButton")
            {
                b.gameObject.SetActive(false);
            }
           
        }
        nickNameField.gameObject.SetActive(true);
    }
}
