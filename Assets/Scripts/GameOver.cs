using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    public Text Timer;
    public Text BlueScore;
    public Text RedScore;
    public GameObject WhoWon;
    public GameObject Panel;
    public GameObject PostGame;
    // Update is called once per frame
    void Update()
    {
        Debug.Log(Timer.text);
        if(Timer.text.Equals("00:00"))
        {
            if(int.Parse(BlueScore.text)>int.Parse(RedScore.text))
            {
                WhoWon.GetComponent<Text>().text = "Blue team won!";
            }
            else if(int.Parse(BlueScore.text) < int.Parse(RedScore.text))
            {
                WhoWon.GetComponent<Text>().text = "Red team won!";
            }
            else
            {
                WhoWon.GetComponent<Text>().text = "Draw!";
            }
            PostGame.GetComponent<PostGame>().PostGameGenerator();
        }
    }
}
