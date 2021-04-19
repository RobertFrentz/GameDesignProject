
using ExitGames.Client.Photon;
using Photon.Realtime;
using Photon.Pun;

public static class PhotonSendEvent
{
    public static void BoostPadCollected(int boostPadNumber)
    {
        object[] content = new object[] { boostPadNumber};
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
        PhotonNetwork.RaiseEvent(10, content, raiseEventOptions, SendOptions.SendReliable);
    }
}
