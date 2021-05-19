using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string SceneName;

    public void SceneChange()
    {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene(SceneName);
        //Debug.Log(GameObject.Find("PlayContainer"));
        //GameObject.Find("PlayContainer").SetActive(false);
        
    }
}
