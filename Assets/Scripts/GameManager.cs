using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject playerPrefabRed;
    public GameObject playerPrefabBlue;
    public GameObject ballPrefab;
    public Text boost;
    private GameObject player;
    private Vector3 player1Position = new Vector3(35f, 1f, 28f);
    private Vector3 player2Position = new Vector3(175f, 1, 69f);
    private Vector3 player3Position = new Vector3(35f, 1f, 69f);
    private Vector3 player4Position = new Vector3(175f, 1f, 28f);
    private Vector3 orangeTeamRotation = new Vector3(0f, 90f, 0f);
    private Vector3 blueTeamRotation = new Vector3(0f, -90f, 0f);
    void Start()
    {
        if (playerPrefabRed == null || playerPrefabBlue == null)
        {
            Debug.LogError("<Color=Red><a>Missing</a></Color> playerPrefab Reference. Please set it up in GameObject 'Game Manager'", this);
        }
        else
        {
            Debug.Log(ScenesData.playerNumber);
            if(ScenesData.playerNumber == 1)
            {
                player = PhotonNetwork.Instantiate(this.playerPrefabRed.name, player1Position, Quaternion.Euler(orangeTeamRotation), 0);
            }
            else if(ScenesData.playerNumber == 2)
            {
                player = PhotonNetwork.Instantiate(this.playerPrefabBlue.name, player2Position, Quaternion.Euler(blueTeamRotation), 0);
            }
            else if(ScenesData.playerNumber == 3)
            {
                player = PhotonNetwork.Instantiate(this.playerPrefabRed.name, player3Position, Quaternion.Euler(orangeTeamRotation), 0);
            }
            else if(ScenesData.playerNumber == 4)
            {
                player = PhotonNetwork.Instantiate(this.playerPrefabBlue.name, player4Position, Quaternion.Euler(blueTeamRotation), 0);
            }
            // we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
            
        }
        if(PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.InstantiateRoomObject(ballPrefab.name, new Vector3(127.3f, 14f, 50.05f), Quaternion.identity, 0);
        }
    }

    void Update()
    {
        boost.text = Math.Floor(player.GetComponent<CarController>().boostBar).ToString();
    }
}
