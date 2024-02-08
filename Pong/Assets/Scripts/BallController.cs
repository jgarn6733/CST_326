using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float moveSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody ballRb = GetComponent<Rigidbody>();
        ballRb.AddForce(Vector3.right *  moveSpeed, ForceMode.Impulse);
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody ballRb = GetComponent<Rigidbody>();
        ballRb.velocity = ballRb.velocity.normalized * moveSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        moveSpeed++;
        Rigidbody ballRb = GetComponent<Rigidbody>();
        ballRb.velocity = ballRb.velocity.normalized * moveSpeed;
       
        
    }
}
