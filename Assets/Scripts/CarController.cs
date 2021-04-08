
using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public InputManager inputManager;
    public List<Transform> visualWheels;
    public List<WheelCollider> throttleWheels;
    public List<WheelCollider> steerWheels;
    public float force;
    public float maxTurn;
    public float brakeStrength;
    public float maxSpeed;
    private Rigidbody rb;
    private bool grounded;
    private float boost;
    private float timeStart;
    private float timeEnd;
    private float dragOnGround = 3f;
    private float doubleJumpButtonPressed;
    public LayerMask whatIsGround;
    public float groundRayLength;
    public Transform[] groundRayPoints;
    public PhotonView photonView;
    public ParticleSystem[] carBoost;
    void Start()
    {
        timeStart = 0f;
        timeEnd = 4f;
        doubleJumpButtonPressed = 0;
        inputManager = GetComponent<InputManager>();
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0.1f, 0.1f, 0.1f);
    }

    void FixedUpdate()
    {
        if (photonView.IsMine)
        {
            grounded = false;
            RaycastHit hit;
            boost = 1f;
            if (timeStart >= 0.1f && timeStart <= timeEnd)
            {
                timeStart += Time.deltaTime;
            }
            foreach(var groundRay in groundRayPoints)
            {
                if (Physics.Raycast(groundRay.position, -transform.up, out hit, groundRayLength, whatIsGround))
                {
                    grounded = true;
                }
            }

            if (Input.GetButton("Fire1"))
            {
                carBoost[0].Play();
                carBoost[1].Play();
                boost = 10000f;
            }
            else
            {
                carBoost[0].Stop();
                carBoost[1].Stop();
            }

            if (Input.GetKey(KeyCode.R))
            {
                rb.transform.position = new Vector3(48, 1, 6);
                rb.velocity = new Vector3(0f, 0f, 0f);
                rb.rotation = Quaternion.identity;
            }

            if (grounded)
            {
                timeStart = 0f;
                if (rb.velocity.magnitude < maxSpeed)
                {
                    float throttle = inputManager.throttle;
                    var localVel = transform.InverseTransformDirection(rb.velocity);
                    CarMovement(boost, localVel.z);
                }
                else
                {
                    rb.velocity = rb.velocity.normalized * maxSpeed;
                }
                foreach (WheelCollider wheelCollider in steerWheels)
                {
                    wheelCollider.steerAngle = maxTurn * inputManager.steer;
                    /*wheelFrontLeft.transform.localEulerAngles = new Vector3(0f, wheelCollider.steerAngle, 0f);
                    wheelFrontRight.transform.localEulerAngles = new Vector3(0f, wheelCollider.steerAngle, 0f);*/
                    //Debug.Log("SteerAngle: " + wheelCollider.steerAngle);
                }
                /*wheelFrontLeft.transform.Rotate(throttleWheels[0].rpm / 60 * 360 * Time.deltaTime, 0, 0, Space.Self);
                wheelFrontRight.transform.Rotate(throttleWheels[1].rpm / 60 * 360 * Time.deltaTime, 0, 0, Space.Self);
                wheelRearLeft.transform.Rotate(throttleWheels[2].rpm / 60 * 360 * Time.deltaTime, 0, 0, Space.Self);
                wheelRearLeft.transform.Rotate(throttleWheels[3].rpm / 60 * 360 * Time.deltaTime, 0, 0, Space.Self);*/
                if (Input.GetButtonDown("Fire2"))
                {
                    rb.AddForce(rb.transform.up * 600000f);
                    timeStart = 0.1f;
                }
            }
            else
            {
                if (inputManager.throttle > 0)
                {
                    if (Input.GetButtonDown("Fire2") && timeStart > 0.1f && timeStart < timeEnd)
                    {
                        rb.AddTorque(rb.transform.right * 900000f);
                        rb.AddForce(rb.transform.forward * 800000f);
                    }
                    else
                    {
                        Quaternion deltaRotation = Quaternion.Euler(new Vector3(170f, 0f, 0f) * Time.deltaTime);
                        rb.MoveRotation(rb.rotation * deltaRotation);
                    }

                }
                else if (inputManager.throttle < 0)
                {
                    if (Input.GetButtonDown("Fire2") && timeStart > 0.1f && timeStart < timeEnd)
                    {
                        rb.AddTorque(-rb.transform.right * 900000f);
                        rb.AddForce(-rb.transform.forward * 800000f);
                    }
                    else
                    {
                        Quaternion deltaRotation = Quaternion.Euler(new Vector3(-170f, 0f, 0f) * Time.deltaTime);
                        rb.MoveRotation(rb.rotation * deltaRotation);
                    }

                }
                if (inputManager.steer > 0)
                {
                    if (Input.GetButtonDown("Fire2") && timeStart > 0.1f && timeStart < timeEnd)
                    {
                        rb.AddTorque(rb.transform.forward * 900000f);
                        rb.AddForce(rb.transform.right * 800000f);
                    }
                    else
                    {
                        Quaternion deltaRotation = Quaternion.Euler(new Vector3(0f, 170f, 0f) * Time.deltaTime);
                        rb.MoveRotation(rb.rotation * deltaRotation);
                    }
                    
                }
                if (inputManager.steer < 0)
                {
                    if (Input.GetButtonDown("Fire2") && timeStart > 0.1f && timeStart < timeEnd)
                    {
                        rb.AddTorque(-rb.transform.forward * 900000f);
                        rb.AddForce(-rb.transform.right * 800000f);
                    }
                    else
                    {
                        Quaternion deltaRotation = Quaternion.Euler(new Vector3(0f, -170f, 0f) * Time.deltaTime);
                        rb.MoveRotation(rb.rotation * deltaRotation);
                    }
                    
                }
                if (Input.GetKey(KeyCode.Q))
                {
                    Quaternion deltaRotation = Quaternion.Euler(new Vector3(0f, 0f, 170f) * Time.deltaTime);
                    rb.MoveRotation(rb.rotation * deltaRotation);
                }
                if (Input.GetKey(KeyCode.E))
                {
                    Quaternion deltaRotation = Quaternion.Euler(new Vector3(0f, 0f, -170f) * Time.deltaTime);
                    rb.MoveRotation(rb.rotation * deltaRotation);
                }
                if(boost > 1)
                {
                    rb.AddForce(rb.transform.forward * boost * 5f);
                }
            }
        }

    }

    public void CarMovement(float boost, float direction)
    {
        for (int i = 0; i < 4; i++)
        {
            Quaternion rotation;
            Vector3 position;
            if(boost == 1)
            {
                if(direction > 0)
                {
                    if(inputManager.throttle > 0)
                    {
                        throttleWheels[i].motorTorque = force * inputManager.throttle;
                        throttleWheels[i].brakeTorque = 0;
                    }
                    else if(inputManager.throttle < 0)
                    {
                        throttleWheels[i].motorTorque = 0.1f;
                        throttleWheels[i].brakeTorque = brakeStrength;
                    }
                } 
                else if(direction < 0)
                {
                    if (inputManager.throttle > 0)
                    {
                        throttleWheels[i].motorTorque = 0.1f;
                        throttleWheels[i].brakeTorque = brakeStrength;
                    }
                    else if (inputManager.throttle < 0)
                    {
                        throttleWheels[i].motorTorque = force * inputManager.throttle;
                        throttleWheels[i].brakeTorque = 0;
                    }
                }
            }
            else if (boost > 1)
            {
                rb.AddForce(rb.transform.forward * boost);
                /*if (direction > 0)
                {
                    throttleWheels[i].motorTorque = force * boost;
                }
                else if (direction < 0)
                {
                    if (rb.velocity.magnitude > 0.1)
                    {
                        throttleWheels[i].motorTorque = 0;
                        throttleWheels[i].brakeTorque = brakeStrength;
                    }
                    else
                    {
                        if (inputManager.throttle > 0)
                        {
                            throttleWheels[i].motorTorque = force * inputManager.throttle * boost;
                        }
                        else
                        {
                            throttleWheels[i].motorTorque = force * boost;
                        }

                    }

                }*/
            }
            throttleWheels[i].GetWorldPose(out position, out rotation);
            visualWheels[i].position = position;
            visualWheels[i].rotation = rotation;
        }
    }
}
