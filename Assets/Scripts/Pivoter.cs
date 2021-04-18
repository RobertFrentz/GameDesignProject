using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Pivoter : MonoBehaviour
{
    private GameObject ball;
    private Transform cube;
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("SoccerBall");
        cube = transform.GetChild(4);
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
            cube.LookAt(ball.transform.position);
        }
        
    }
}
