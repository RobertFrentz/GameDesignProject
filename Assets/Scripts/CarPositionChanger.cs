﻿using Photon.Pun;
using UnityEngine;

public class CarPositionChanger : MonoBehaviour, IPunObservable
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
        _rb.velocity = Vector3.zero;
    }
    void Update()
    {
        if(_rb==null)
        {
            _rb = GetComponent<Rigidbody>();
            _rb.velocity = Vector3.zero;
        }
    }
    public void FixedUpdate()
    {
        var photonView = GameObject.FindGameObjectWithTag("Car").GetComponent<PhotonView>();
        if(photonView!=null)
        {
            if (!photonView.IsMine)
            {
                _rb.position = Vector3.MoveTowards(_rb.position, _networkPosition, Time.fixedDeltaTime);
                _rb.rotation = Quaternion.RotateTowards(_rb.rotation, _networkRotation, Time.fixedDeltaTime * 100.0f);
                
            }
        }
       
    }
}
