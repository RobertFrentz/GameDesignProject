using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject ballPrefab;
    public Text boost;
    private GameObject player;
    void Start()
    {
        if (playerPrefab == null)
        {
            Debug.LogError("<Color=Red><a>Missing</a></Color> playerPrefab Reference. Please set it up in GameObject 'Game Manager'", this);
        }
        else
        {
            // we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
            player = PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(48f, 10f, 0f), Quaternion.identity, 0);
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
