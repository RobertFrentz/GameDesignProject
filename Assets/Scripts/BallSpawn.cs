using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ballSpawn;
    public GameObject ball;
    public Text redScore;
    public Text blueScore;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="SoccerBall")
        {
            ball.transform.position = ballSpawn.transform.position;
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            
            if(name == "GoalCollider1")
            {
                int currentRedScoreValue = int.Parse(redScore.text);
                redScore.text = (currentRedScoreValue + 1).ToString();
            }
            else if (name == "GoalCollider2")
            {
                int currentBlueScoreValue = int.Parse(blueScore.text);
                blueScore.text = (currentBlueScoreValue + 1).ToString();
            }
        }
    }
}
