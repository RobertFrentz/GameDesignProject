
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public InputManager inputManager;
    public List<WheelCollider> throttleWheels;
    public List<WheelCollider> steerWheels;
    public float force;
    public float maxTurn;
    void Start()
    {
        inputManager = GetComponent<InputManager>();
    }

    void FixedUpdate()
    {
        foreach(WheelCollider wheelCollider in throttleWheels)
        {
            wheelCollider.motorTorque = force * Time.fixedDeltaTime * inputManager.throttle;
            //Debug.Log("MotorTorque: " + wheelCollider.motorTorque);
        }
        foreach(WheelCollider wheelCollider in steerWheels)
        {
            wheelCollider.steerAngle = maxTurn * inputManager.steer;
            //Debug.Log("SteerAngle: " + wheelCollider.steerAngle);
        }
    }
}
