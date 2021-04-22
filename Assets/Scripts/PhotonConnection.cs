using Photon.Pun;
using Photon.Realtime;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PhotonConnection : MonoBehaviourPunCallbacks
{
    public Button button1v1;
    public Button button2v2;
    public static string button;
    [SerializeField]
    private byte maxPlayersPerRoom2vs2 = 4;
    private byte maxPlayersPerRoom1vs1 = 2;

    /// <summary>
    /// This client's version number. Users are separated from each other by gameVersion (which allows you to make breaking changes).
    /// </summary>
    string gameVersion = "1";
    //PhotonSendEvent photonSendEvent = new PhotonSendEvent();




    /// <summary>
    /// MonoBehaviour method called on GameObject by Unity during early initialization phase.
    /// </summary>
    void Awake()
    {
        // #Critical
        // this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
        PhotonNetwork.AutomaticallySyncScene = true;
    }


    /// <summary>
    /// MonoBehaviour method called on GameObject by Unity during initialization phase.
    /// </summary>
    void Start()
    {
        Connect();
    }







    /// <summary>
    /// Start the connection process.
    /// - If already connected, we attempt joining a random room
    /// - if not yet connected, Connect this application instance to Photon Cloud Network
    /// </summary>
    public void Connect()
    {
        // we check if we are connected or not, we join if we are , else we initiate the connection to the server.
        if (PhotonNetwork.IsConnected)
        {
            Debug.Log("I'm connected already");
        }
        else
        {
            Debug.Log("Connecting now");
            // #Critical, we must first and foremost connect to Photon Online Server.
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = gameVersion;

        }
    }


    public void CreateRoom(byte maxPlayersPerRoom)
    {

        System.Random random = new System.Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        string room= new string(Enumerable.Range(1, 7).Select(_ => chars[random.Next(chars.Length)]).ToArray());
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = maxPlayersPerRoom;
        PhotonNetwork.CreateRoom(room, roomOptions, null);

    }

    public void DisconnectFromRoom()
    {

        PhotonNetwork.LeaveRoom();
    }

    public void JoinRoom(string buttonName)
    {
        button = buttonName;
        if(buttonName=="1vs1")
        {

            PhotonNetwork.JoinRandomRoom(null, maxPlayersPerRoom1vs1);
        }
        else if(buttonName == "2vs2")
        {
            PhotonNetwork.JoinRandomRoom(null, maxPlayersPerRoom2vs2);
        }
    }


    public override void OnCreatedRoom()
    {
        Debug.Log("Connected to room" + PhotonNetwork.CurrentRoom.Name);
    }
    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
    }


    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(button);
        if (PhotonNetwork.IsMasterClient)
        {
            Debug.Log("Da, eu sunt master");
            if(button=="1vs1")
            {
                Debug.Log("dupa 1v1 button");
                if (PhotonNetwork.CurrentRoom.PlayerCount==2)
                {
                    Debug.Log(PhotonNetwork.CurrentRoom.Name);
                    PhotonNetwork.LoadLevel("GameScene1");
                }
            }
            else if (button=="2vs2")
            {
                if (PhotonNetwork.CurrentRoom.PlayerCount == 4)
                {
                    Debug.Log(PhotonNetwork.CurrentRoom.Name);
                    PhotonNetwork.LoadLevel("GameScene1");
                }
            }
        }
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("PUN Basics Tutorial/Launcher: OnConnectedToMaster() was called by PUN");
        //JoinRoom();

    }


    public override void OnJoinedRoom()
    {
        ScenesData.playerNumber = PhotonNetwork.CurrentRoom.PlayerCount;
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarningFormat("PUN Basics Tutorial/Launcher: OnDisconnected() was called by PUN with reason {0}", cause);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("PUN Basics Tutorial/Launcher:OnJoinRandomFailed() was called by PUN. No random room available");
        if (button == "1vs1")
        {
            CreateRoom(maxPlayersPerRoom1vs1);
        }
        else if (button == "2vs2")
        {
            CreateRoom(maxPlayersPerRoom2vs2);
        }
        // #Critical: we failed to join a random room, maybe none exists or they are all full. No worries, we create a new room.
        //PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
    }


    /*public override void OnJoinedRoom()
    {

        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            PhotonNetwork.LoadLevel("GameScene1");
        }
        Debug.Log("PUN Basics Tutorial/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");
    }*/
}