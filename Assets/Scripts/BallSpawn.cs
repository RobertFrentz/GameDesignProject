using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ballSpawn;
    public GameObject ball;
    public Text score;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="SoccerBall")
        {
            ball.transform.position = ballSpawn.transform.position;
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            
            int currentScoreValue = int.Parse(score.text);
            score.text = (currentScoreValue + 1).ToString();
        }
    }
    private void Update()
    {
        if (Input.GetButtonDown("BallReset"))
        {
            ball.transform.position = ballSpawn.transform.position;
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }
}
