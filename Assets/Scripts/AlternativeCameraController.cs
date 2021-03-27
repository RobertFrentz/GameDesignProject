
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
    private bool ballCamera = false;

    void Start()
    {

        if (followOnStart)
        {
            OnStartFollowing();
        }
    }


    void LateUpdate()
    {

        if (cameraTransform == null && isFollowing)
        {
            OnStartFollowing();
        }

        if (isFollowing)
        {
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
        cameraTransform.position = this.transform.position - new Vector3(0f, -1.5f, 5f);
        cameraTransform.LookAt(this.transform.position);
    }

    void FollowBall()
    {
        cameraOffset.z = -distance;
        cameraOffset.y = height;
        cameraTransform.position = Vector3.Lerp(cameraTransform.position, this.transform.position + this.transform.TransformVector(cameraOffset), smoothSpeed * Time.deltaTime);
        cameraTransform.LookAt(this.transform.position);
    }


    void Cut()
    {
        cameraTransform.position = this.transform.position - new Vector3(0f, -1.5f, 5f);
        cameraTransform.LookAt(this.transform.position);
    }
}
