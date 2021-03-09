
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public InputManager inputManager;
    public GameObject wheelFrontLeft;
    public GameObject wheelFrontRight;
    public GameObject wheelRearLeft;
    public GameObject wheelRearRight;
    public List<WheelCollider> throttleWheels;
    public List<WheelCollider> steerWheels;
    public float force;
    public float maxTurn;
    public float maxSpeed;
    private Rigidbody rb;
    void Start()
    {
        inputManager = GetComponent<InputManager>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if(rb.velocity.magnitude < maxSpeed)
        {
            foreach (WheelCollider wheelCollider in throttleWheels)
            {
                wheelCollider.motorTorque = force * Time.fixedDeltaTime * inputManager.throttle;
                //Debug.Log("MotorTorque: " + wheelCollider.motorTorque);
            }
        }
        else
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
        foreach(WheelCollider wheelCollider in steerWheels)
        {
            wheelCollider.steerAngle = maxTurn * inputManager.steer;
            wheelFrontLeft.transform.localEulerAngles = new Vector3(0f, wheelCollider.steerAngle, 0f);
            wheelFrontRight.transform.localEulerAngles = new Vector3(0f, wheelCollider.steerAngle, 0f);
            //Debug.Log("SteerAngle: " + wheelCollider.steerAngle);
        }

        wheelFrontLeft.transform.Rotate(throttleWheels[0].rpm / 60 * 360 * Time.deltaTime, 0, 0, Space.Self);
        wheelFrontRight.transform.Rotate(throttleWheels[1].rpm / 60 * 360 * Time.deltaTime, 0, 0, Space.Self);
        wheelRearLeft.transform.Rotate(throttleWheels[2].rpm / 60 * 360 * Time.deltaTime, 0, 0, Space.Self);
        wheelRearLeft.transform.Rotate(throttleWheels[3].rpm / 60 * 360 * Time.deltaTime, 0, 0, Space.Self);
    }
}
