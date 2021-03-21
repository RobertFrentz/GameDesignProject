
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
    public float brakeStrength;
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
            float throttle = inputManager.throttle;
            var localVel = transform.InverseTransformDirection(rb.velocity);
            foreach (WheelCollider wheelCollider in throttleWheels)
            {
                if(localVel.z > 0)
                {
                    if(throttle < 0)
                    {
                        wheelCollider.motorTorque = 0;
                        wheelCollider.brakeTorque = brakeStrength;
                    }
                    else
                    {
                        wheelCollider.motorTorque = force * Time.deltaTime * inputManager.throttle;
                        wheelCollider.brakeTorque = 0;
                    }
                }
                else
                {
                    if (throttle > 0)
                    {
                        wheelCollider.motorTorque = 0;
                        wheelCollider.brakeTorque = brakeStrength * Time.deltaTime;
                    }
                    else
                    {
                        wheelCollider.motorTorque = force * Time.deltaTime * inputManager.throttle;
                        wheelCollider.brakeTorque = 0;
                    }
                }

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
