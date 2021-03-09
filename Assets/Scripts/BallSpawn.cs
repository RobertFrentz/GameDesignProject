using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ballSpawn;
    public GameObject ball;
    public ScoreChanger scoreChanger;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="SoccerBall")
        {
            ball.transform.position = ballSpawn.transform.position;
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            scoreChanger.ScoreGoal();
        }
    }
}
