using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhotonConnection : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private byte maxPlayersPerRoom = 4;

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


    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = maxPlayersPerRoom;
        PhotonNetwork.CreateRoom("Alabala", roomOptions, null);

    }

    public void DisconnectFromRoom()
    {
        PhotonNetwork.LeaveRoom();

    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }


    public override void OnCreatedRoom()
    {
        Debug.Log("Connected to room" + PhotonNetwork.CurrentRoom.Name);
    }
    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        /*        SceneManager.LoadScene("Home");
                ScenesData.currentRiddle = 1;
                ScenesData.numberOfRiddles = 1;
                ScenesData.treasureCoords = new double[2];
                ScenesData.riddlesCoords = new double[10];
                ScenesData.riddlesText = new string[6];*/
    }


    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
            {
                /*ScenesData.playerNumber = 1;*/
                PhotonNetwork.LoadLevel("GameScene1");
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


    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarningFormat("PUN Basics Tutorial/Launcher: OnDisconnected() was called by PUN with reason {0}", cause);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("PUN Basics Tutorial/Launcher:OnJoinRandomFailed() was called by PUN. No random room available");
        CreateRoom();
        // #Critical: we failed to join a random room, maybe none exists or they are all full. No worries, we create a new room.
        //PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
    }

    
    /*public override void OnJoinedRoom()
    {
        *//*ScenesData.backToLobby = true;*//*
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            *//*ScenesData.playerNumber = 1;*//*
            PhotonNetwork.LoadLevel("GameScene1");
        }
        Debug.Log("PUN Basics Tutorial/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");
    }*/
}