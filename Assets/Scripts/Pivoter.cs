using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivoter : MonoBehaviour
{
    public GameObject ball;
    private Transform cube;
    void Start()
    {
        cube = transform.GetChild(4);
    }

    void LateUpdate()
    {
        cube.LookAt(ball.transform.position);
    }
}
