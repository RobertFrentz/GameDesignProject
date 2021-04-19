using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon;
using Photon.Realtime;
using Photon.Pun;

public class PhotonReceiveEvent : MonoBehaviour, IOnEventCallback
{
    public GameObject[] boostPads;
    private void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    private void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    public void OnEvent(EventData photonEvent)
    {
        byte eventCode = photonEvent.Code;
        if (eventCode == 10)
        {
            object[] data = (object[])photonEvent.CustomData;
            int boostPadNumber = (int)data[0];
            boostPads[boostPadNumber].GetComponent<BoostPad>().ChangeMaterial();
        }
    }
}
