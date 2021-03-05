using UnityEngine;

public class FollowBall : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        transform.position = desiredPosition;
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Do something here");
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Soccer Ball")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("Do something here");
        }
    }

}
//https://answers.unity.com/questions/1246660/how-to-make-an-object-move-but-not-rotate.html
