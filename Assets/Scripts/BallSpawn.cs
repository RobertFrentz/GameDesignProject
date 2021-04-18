using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ballSpawn;
    public Text score;

    /*private void Start()
    {
        fuckingBall = GameObject.FindGameObjectWithTag("SoccerBall");
    }*/
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="SoccerBall")
        { 
            int currentScoreValue = int.Parse(score.text);
            score.text = (currentScoreValue + 1).ToString();
        }
    }
    private void Update()
    {
        if (Input.GetButtonDown("BallReset"))
        {
            GameObject.FindGameObjectWithTag("SoccerBall").transform.position = ballSpawn.transform.position;
            GameObject.FindGameObjectWithTag("SoccerBall").GetComponent<Rigidbody>().velocity = Vector3.zero;
            GameObject.FindGameObjectWithTag("SoccerBall").GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }
}
