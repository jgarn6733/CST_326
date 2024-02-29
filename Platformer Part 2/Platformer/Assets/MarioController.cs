using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MarioController : MonoBehaviour
{
    public float speed = 10f;
    public float maxSpeed = 10f;
    public float jumpImpulse = 50f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinsText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity += Vector3.right * horizontalMovement * Time.deltaTime * speed;

        if (rb.velocity.x > maxSpeed)
        {
            Vector3 newVel = rb.velocity;
            newVel.x = maxSpeed;
            rb.velocity = newVel;
        }

        Collider col = GetComponent<Collider>();
        float halfHeight = col.bounds.extents.y;

        Vector3 startPoint = transform.position;
        Vector3 endPoint = startPoint + Vector3.down * halfHeight;

        bool isGrounded = Physics.Raycast(startPoint, Vector3.down, halfHeight);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpImpulse, ForceMode.Impulse);
        }

        Animator animator = GetComponent<Animator>();
        float moveSpeed = rb.velocity.x;
        animator.SetFloat("Speed", Math.Abs(moveSpeed));
        if (isGrounded)
        {
            animator.SetBool("inAir", false);
        } else
        {
            animator.SetBool("inAir", true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collided = collision.gameObject;
        if (collided.name == "Brick(Clone)")
        {
            float marioY = GetComponent<Transform>().position.y;
            float brickBottom = collided.transform.position.y - 0.5f;
            if (marioY < brickBottom)
            {
                Destroy(collided);
                GameManager.addScore(scoreText);
            }
            
        } else if (collided.name == "Question(Clone)")
        {
            float marioY = GetComponent<Transform>().position.y;
            float questionBottom = collided.transform.position.y - 0.5f;
            if (marioY < questionBottom)
            {
                Destroy(collided);
                GameManager.addCoins(scoreText, coinsText);
            }
        }
    }
}
