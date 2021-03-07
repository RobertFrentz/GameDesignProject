using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivoter : MonoBehaviour
{
    public GameObject ball;
    void LateUpdate()
    {
        transform.LookAt(ball.transform.position);
    }
}
