using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    public Button exitButton;

    void Start()
    {
        exitButton.gameObject.SetActive(false);
    }


    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            exitButton.gameObject.SetActive(!exitButton.gameObject.activeSelf);
        }
    }
}
