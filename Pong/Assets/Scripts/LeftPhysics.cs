using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPhysics : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Quaternion bounceRotation = Quaternion.Euler(0f, 60f, 0f);
        Vector3 bounceDirection = bounceRotation * Vector3.right;

        BoxCollider leftCollider = GameObject.Find("LeftPaddle").GetComponent<BoxCollider>();
        Bounds leftBounds = leftCollider.bounds;
        float leftMaxZ = leftBounds.max.z;
        float leftMinZ = leftBounds.min.z;

        Rigidbody collideRb = collision.rigidbody;
        collideRb.AddForce(bounceDirection, ForceMode.Force);
    }
}
