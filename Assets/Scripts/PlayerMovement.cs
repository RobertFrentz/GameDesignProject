using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public GameObject player;
    public float speed;
    private Rigidbody playerRB;
    private Vector3 movement;
    void Start()
    {
        playerRB = player.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        movement = new Vector3(horizontal, 0f, vertical).normalized;
        Debug.Log(movement);
        playerRB.AddForce(player.transform.position + (movement * speed) , ForceMode.Force) ;
    }
}
