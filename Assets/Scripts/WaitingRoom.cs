using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WaitingRoom : MonoBehaviour
{
    public int secondLeft = 3;
    public bool takingAway = false;
    public GameObject Photon;
    Text waitingText;

    void Update()
    {

        if (takingAway == false && secondLeft > 0)
        {
            StartCoroutine(TimerTake());
            
        }
        if (secondLeft <= 0)
        {
            waitingText = GetComponent<Text>();
            waitingText.gameObject.SetActive(false);
            Photon.GetComponent<PhotonConnection>().JoinRoom();
        }
    }


    public IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondLeft -= 1;
        takingAway = false;
    }
}
