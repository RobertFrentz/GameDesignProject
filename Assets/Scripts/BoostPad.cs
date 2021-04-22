using System;

using UnityEngine;

public class BoostPad : MonoBehaviour
{
    private int boostNumber;
    private Renderer renderer;
    private float timeStart;
    private float timeEnd;
    private Renderer bigBoost;

    void Start()
    {
        boostNumber = Int32.Parse(this.gameObject.name.Substring(6));
        timeStart = -1f;
        timeEnd = 10f;
        renderer = GetComponent<Renderer>();
        if(transform.parent.childCount == 2)
        {
            bigBoost = transform.parent.GetChild(1).GetComponent<Renderer>();
        }
        renderer.material.color = Color.yellow;
    }

    void Update()
    {
        if (timeStart != -1f && timeStart < timeEnd)
        {
            timeStart += Time.deltaTime;
            Debug.Log(timeStart);
        }
        if (timeStart >= timeEnd)
        {
            timeStart = -1f;
            renderer.material.color = Color.yellow;
            bigBoost.enabled = !bigBoost.enabled;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(renderer.material.color == Color.white)
        {
            return;
        }
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
        renderer.material.color = Color.white;
        if(bigBoost != null)
        {
            bigBoost.enabled = !bigBoost.enabled;
        }
        timeStart = 0f;
    }
}
