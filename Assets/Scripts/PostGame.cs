using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PostGame : MonoBehaviour
{
    public Text player1Nickname;
    public Text player2Nickname;
    public Text player3Nickname;
    public Text player4Nickname;
    public Text postGameRedScore;
    public Text postGameBlueScore;
    public Text redScore;
    public Text blueScore;
    private int playerCountRed;
    private int playerCountBlue;

    void Start()
    {
        playerCountRed = 0;
        playerCountBlue = 0;
    }

    void Update()
    {

    }

    public void PostGameGenerator()
    {
        var cars = GameObject.FindGameObjectsWithTag("Car");
        if (cars != null)
        {
            foreach (GameObject gameObject in cars)
            {
                string nickname = gameObject.transform.GetComponent<PhotonView>().Owner.NickName;
                if (gameObject.name.Contains("CarRed"))
                {
                    if (playerCountRed == 0)
                    {
                        player1Nickname.text = nickname;
                        playerCountRed++;
                    }
                    else if (playerCountRed == 1)
                    {
                        player3Nickname.text = nickname;
                        playerCountRed++;
                    }
                }
                else if (gameObject.name.Contains("CarBlue"))
                {
                    if (playerCountBlue == 0)
                    {
                        player2Nickname.text = nickname;
                        playerCountBlue++;
                    }
                    else if (playerCountBlue == 1)
                    {
                        player4Nickname.text = nickname;
                        playerCountBlue++;
                    }
                }
                gameObject.SetActive(false);
            }
            if (playerCountRed == 1 && playerCountBlue == 1)
            {
                player3Nickname.gameObject.SetActive(false);
                player4Nickname.gameObject.SetActive(false);
            }
            postGameRedScore.text = redScore.text;
            postGameBlueScore.text = blueScore.text;
            Camera.main.transform.position = new Vector3(102, 46, 152);
            Camera.main.transform.rotation = Quaternion.Euler(new Vector3(20, 180, 0));
            for (int i = 0; i < this.transform.childCount; i++)
            {
                this.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
}
