using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject cam;
    public GameObject car;
    public GameObject cameraRig;
    public GameObject ballRig;
    public GameObject target;
    public GameObject ball;

    // Update is called once per frame
    void BallCam()
    {
        cam.transform.position = ballRig.transform.position;
        cam.transform.LookAt(ball.transform.position);

    }
    void CarCam()
    {
        cam.transform.position = cameraRig.transform.position;
        cam.transform.LookAt(car.transform.position);
    }
    void Update()
    {
        //CarCam();
        BallCam();
    }
}
