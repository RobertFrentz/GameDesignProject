using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayName : MonoBehaviour
{
    private GameObject sign;
    [SerializeField]
    public GameObject player;
    private bool isSignActive = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!GetComponent<PhotonView>().IsMine)
        {
            isSignActive = true;
            GameObject sign = new GameObject("player_label");
            sign.transform.rotation = Camera.main.transform.rotation; // Causes the text faces camera.
            Debug.Log(sign.transform.rotation);
            TextMesh tm = sign.AddComponent<TextMesh>();
            tm.text = this.GetComponent<PhotonView>().Owner.NickName;
            if (this.transform.name.Contains("Blue"))
            {
                tm.color = Color.blue;
            }
            else
            {
                tm.color = Color.red;
            }
            tm.fontStyle = FontStyle.Bold;
            tm.alignment = TextAlignment.Center;
            tm.anchor = TextAnchor.MiddleCenter;
            tm.characterSize = 0.065f;
            tm.fontSize = 90;
            this.sign = sign;
        }  
    }

    // Update is called once per frame
    void Update()
    {
        if (isSignActive)
        {
            sign.transform.position = player.transform.position + Vector3.up * 2f;
            sign.transform.LookAt(Camera.main.transform);
            sign.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
        }
        
        //TextMesh tm = sign.GetComponent<TextMesh>();
        //tm.transform.rotation = new Quaternion(tm.transform.rotation.x-180,tm.transform.rotation.y,tm.transform.rotation.z,tm.transform.rotation.w);
        //sign.transform.rotation = new Quaternion(sign.transform.rotation.x-180,sign.transform.rotation.y,sign.transform.rotation.z,sign.transform.rotation.w);
    }
}
