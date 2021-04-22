using System;

using UnityEngine;

public class BoostPad : MonoBehaviour
{
    private int boostNumber;
    private Renderer renderer;
    private float timeStart;
    private float timeEnd;

    void Start()
    {
        boostNumber = Int32.Parse(this.gameObject.name.Substring(6));
        timeStart = -1f;
        timeEnd = 1000f;
        renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        /*if(timeStart != -1f && timeStart < timeEnd)
        {
            timeStart += Time.deltaTime;
            Debug.Log(timeStart);
        }
        if(timeStart >= timeEnd)
        {
            timeStart = -1f;
            renderer.material.color = Color.yellow;
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        CarController controller = other.GetComponentInParent<CarController>();
        if (controller != null)
        {
            if(controller.boostBar < 100f)
            {
                SendEventOnCollison();
                if (boostNumber < 6)
                {
                    Debug.Log("Small boost");
                    controller.AddSmallBoost();
                    return;
                }
                Debug.Log("Big boost");
                controller.AddFullBoost();
            } 
        } 
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
    }
}
