using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiRollBar : MonoBehaviour
{

    public WheelCollider wheelLeft;
    public WheelCollider wheelRight;
    public Rigidbody rb;
    private float antiRoll = 7000f;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        WheelHit hit;
        float travelL = 1f;
        float travelR = 1f;

        bool groundedL = wheelLeft.GetGroundHit(out hit);
        if (groundedL)
            travelL = (-wheelLeft.transform.InverseTransformPoint(hit.point).y - wheelLeft.radius) / wheelLeft.suspensionDistance;

        var groundedR = wheelRight.GetGroundHit(out hit);
        if (groundedR)
            travelR = (-wheelRight.transform.InverseTransformPoint(hit.point).y - wheelRight.radius) / wheelRight.suspensionDistance;

        var antiRollForce = (travelL - travelR) * antiRoll;

        if (groundedL)
            rb.AddForceAtPosition(wheelLeft.transform.up * -antiRollForce,
                   wheelLeft.transform.position);
        if (groundedR)
            rb.AddForceAtPosition(wheelRight.transform.up * antiRollForce,
                   wheelRight.transform.position);
    }
}
