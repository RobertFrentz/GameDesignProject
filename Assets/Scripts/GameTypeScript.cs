using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTypeScript : MonoBehaviour
{
    public Button _1vs1Button;
    public Button _2vs2Button;
    public Text waitingText;
    void Start()
    {
        _1vs1Button.onClick.AddListener(() => ButtonClicked());
        _2vs2Button.onClick.AddListener(() => ButtonClicked());
    }

    void ButtonClicked()
    {
        _1vs1Button.gameObject.SetActive(false);
        _2vs2Button.gameObject.SetActive(false);
        waitingText.gameObject.SetActive(true);

    }
}
