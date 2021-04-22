using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallPositionChanger :MonoBehaviour, IPunObservable
{
    Vector3 _networkPosition;
    Quaternion _networkRotation;
    Rigidbody _rb;
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        _rb = GetComponent<Rigidbody>();
        if (stream.IsWriting)
        {
            stream.SendNext(_rb.position);
            stream.SendNext(_rb.rotation);
            stream.SendNext(_rb.velocity);
        }
        else
        {
            _networkPosition = (Vector3)stream.ReceiveNext();
            _networkRotation = (Quaternion)stream.ReceiveNext();
            _rb.velocity = (Vector3)stream.ReceiveNext();
            float lag = Mathf.Abs((float)(PhotonNetwork.Time - info.SentServerTime));
            _networkPosition += (_rb.velocity * lag);
        }
    }
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {

        if (!GameObject.FindGameObjectWithTag("SoccerBall").GetComponent<PhotonView>().IsMine)
        {
            _rb.position = Vector3.MoveTowards(_rb.position, _networkPosition, Time.fixedDeltaTime);
            _rb.rotation = Quaternion.RotateTowards(_rb.rotation, _networkRotation, Time.fixedDeltaTime * 100.0f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GoalCollider1"))
        {
            Debug.Log("Am ajuns aici si aici 2");
            _rb.position = GameObject.Find("BallSpawn").transform.position;
            _rb.velocity = Vector3.zero;
            _rb.angularVelocity = Vector3.zero;
        }
        else if(other.gameObject.CompareTag("GoalCollider2"))
        {
            _rb.position = GameObject.Find("BallSpawn").transform.position;
            _rb.velocity = Vector3.zero;
            _rb.angularVelocity = Vector3.zero;
        }
    }
    /* private void OnCollisionEnter(Collision contact)
     {
         Debug.Log("Am ajuns aici-collider");
         Debug.Log(contact);
         if (contact.gameObject.CompareTag("GoalCollider1") || contact.gameObject.CompareTag("GoalCollider2"))
         {
             Debug.Log("Am ajuns aici si aici 2");
             _rb.position = GameObject.Find("BallSpawn").transform.position;
             _rb.velocity = Vector3.zero;
             _rb.angularVelocity = Vector3.zero;

             *//*int currentScoreValue = int.Parse(score.text);
             score.text = (currentScoreValue + 1).ToString();*//*
         }
     }*/
}

