using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivoter : MonoBehaviour
{
    private GameObject ball;
    private Transform cube;
    void Start()
    {
        ball = GameObject.Find("Soccer Ball");
        cube = transform.GetChild(4);
    }

    void LateUpdate()
    {
        cube.LookAt(ball.transform.position);
    }
}
