using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControllerArcade : MonoBehaviour
{
    public Rigidbody sphereRigidbody;
    public InputManager inputManager;

    public float forwardAccel, reverseAccel, maxSpeed, turnStrength, gravityForce;
    private Vector3 offset;
    private float speed;
    private float steer;
    private bool grounded;
    private float dragOnGround = 3f;
    public LayerMask whatIsGround;
    public float groundRayLength;
    public Transform groundRayPoint;
    void Start()
    {
        sphereRigidbody.transform.parent = null;
        offset = new Vector3(0f, 0.5f, 0f);
    }

    void Update()
    {
        if(inputManager.throttle > 0.1)
        {
            speed = inputManager.throttle * forwardAccel * 1000f * Time.deltaTime;
        }
        else if(inputManager.throttle < -0.1)
        {
            speed = inputManager.throttle * reverseAccel * 1000f * Time.deltaTime;
        }
        else
        {
            speed = 0;
        }
        steer = inputManager.steer;

        transform.position = sphereRigidbody.position - offset;
        if (grounded)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, steer * turnStrength * inputManager.throttle * Time.deltaTime * 50f, 0f));
        }
        else
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, steer * turnStrength * Time.deltaTime * 50f, 0f));
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(grounded);
        grounded = false;
        RaycastHit hit;
        //Debug.DrawRay(groundRayPoint.position, -transform.up * groundRayLength, Color.red, Mathf.Infinity);
        if (Physics.Raycast(groundRayPoint.position,-transform.up, out hit, groundRayLength, whatIsGround))
        {
            
            grounded = true;
            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }
        if (grounded)
        {
            sphereRigidbody.drag = dragOnGround;
            if (Mathf.Abs(speed) > 0)
            {
                sphereRigidbody.AddForce(transform.forward * speed);
            }

            if (Input.GetButtonDown("Fire2"))
            {
                sphereRigidbody.AddForce(transform.up * 10000f);
            }
        }
        else
        {
            sphereRigidbody.drag = 0.1f;
            sphereRigidbody.AddForce(Vector3.up * -gravityForce * 70f);
        }
        if (Input.GetButtonDown("Fire1"))
        {

        }
    }
}
