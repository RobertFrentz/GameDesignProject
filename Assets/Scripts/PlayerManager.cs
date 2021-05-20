using Photon.Pun;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public static GameObject LocalPlayerInstance;
    public PhotonView photonView;


    void Awake()
    {
        if (photonView.IsMine)
        {
            PlayerManager.LocalPlayerInstance = this.gameObject;
        }
        // #Critical
        // we flag as don't destroy on load so that instance survives level synchronization, thus giving a seamless experience when levels load.
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        AlternativeCameraController _cameraWork = this.gameObject.GetComponent<AlternativeCameraController>();

        if (_cameraWork != null)
        {
            if (photonView.IsMine)
            {
                _cameraWork.OnStartFollowing();
            }
        }
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision contact)
    {
        Transform collisionObjectRoot = contact.transform.root;
        if (collisionObjectRoot.CompareTag("SoccerBall"))
        {
            GameObject ball = GameObject.FindGameObjectWithTag("SoccerBall");
            if (!ball.GetComponent<PhotonView>().IsMine)
            {
                ball.GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.LocalPlayer);
                //Transfer PhotonView of Rigidbody to our local player
            }

        }
    }
}
