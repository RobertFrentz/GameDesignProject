
using System.Threading;
using UnityEngine;

public class AlternativeCameraController : MonoBehaviour
{

    private float distance = 3f;
    private float height = 3f;
    private bool followOnStart = false;
    private float smoothSpeed = 0.125f;
    Transform cameraTransform;
    bool isFollowing;
    Vector3 cameraOffset = Vector3.zero;
    private GameObject ball;
    private bool ballCamera=true;
    private Transform cameraRig;
    private Transform ballRig;

    void Start()
    {
        
        ball = GameObject.FindGameObjectWithTag("SoccerBall");
        cameraRig = this.transform.GetChild(3);
        ballRig = this.transform.GetChild(4).GetChild(0);
        if (followOnStart)
        {
            OnStartFollowing();
        }
    }
    void Update()
    {
        if(ball==null)
        {
            ball = GameObject.FindGameObjectWithTag("SoccerBall");
        }
    }

    void LateUpdate()
    {
        if(ball!=null)
        {
            if (cameraTransform == null && isFollowing)
            {
                OnStartFollowing();
            }

            if (isFollowing)
            {
                if (Input.GetButtonDown("CameraSwitch"))
                {
                    ballCamera = !ballCamera;
                }
                if (ballCamera)
                {
                    FollowBall();
                }
                else
                {
                    FollowCar();

                }
            }
        }

       
    }

    public void OnStartFollowing()
    {
        cameraTransform = Camera.main.transform;
        isFollowing = true;
        Cut();
    }

    void FollowCar()
    {
        /*cameraOffset.z = -distance;
        cameraOffset.y = height;
        cameraTransform.position = Vector3.Lerp(cameraTransform.position, this.transform.position + this.transform.TransformVector(cameraOffset), smoothSpeed * Time.deltaTime);
        cameraTransform.LookAt(this.transform.position + centerOffset);*/
        cameraTransform.position = cameraRig.position;
        cameraTransform.LookAt(this.transform.position);
    }

    void FollowBall()
    {
        /*cameraOffset.z = -distance;
        cameraOffset.y = height;
        cameraTransform.position = Vector3.Lerp(cameraTransform.position, this.transform.position + this.transform.TransformVector(cameraOffset), smoothSpeed * Time.deltaTime);
        cameraTransform.LookAt(this.transform.position);*/
        cameraTransform.position = ballRig.position;
        cameraTransform.LookAt(ball.transform);
    }


    void Cut()
    {
        cameraTransform.position = this.transform.position - new Vector3(0f, -1.5f, 5f);
        cameraTransform.LookAt(this.transform.position);
    }
}
