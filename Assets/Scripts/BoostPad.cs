using System;

using UnityEngine;

public class BoostPad : MonoBehaviour
{
    private int boostNumber;
    private Renderer renderer;

    void Start()
    {
        boostNumber = Int32.Parse(this.gameObject.name.Substring(11));
        renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        SendEventOnCollison();
        other.GetComponent<CarController>().AddSmallBoost();
    }

    private void SendEventOnCollison()
    {
        PhotonSendEvent.BoostPadCollected(boostNumber);
    }

    public void ChangeMaterial()
    {
        if(renderer.material.color == Color.yellow)
        {
            renderer.material.color = Color.white;
        }
        else
        {
            renderer.material.color = Color.yellow;
        }
    }
}
