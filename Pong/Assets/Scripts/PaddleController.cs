using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float moveSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    void FixedUpdate()
    {
        float leftPaddle = Input.GetAxis("LeftPaddle");
        float rightPaddle = Input.GetAxis("RightPaddle");

        Rigidbody leftRb = GameObject.Find("LeftPaddle").GetComponent<Rigidbody>();
        Rigidbody rightRb = GameObject.Find("RightPaddle").GetComponent<Rigidbody>();

        Vector3 leftForce = Vector3.forward * leftPaddle * moveSpeed;
        Vector3 rightForce = Vector3.forward * rightPaddle * moveSpeed;

        leftRb.AddForce(leftForce, ForceMode.Force);
        rightRb.AddForce(rightForce, ForceMode.Force);
    }

    
}
