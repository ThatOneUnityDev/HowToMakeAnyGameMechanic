using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private bool isGrounded;
    [SerializeField] private Transform groundRayTransform;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private int numJumps;
    [SerializeField] private int jumpForce;
    private int jumpsLeft;
    private float jumpTimer;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.Linecast(transform.position,groundRayTransform.position,groundLayer);

        if (isGrounded == true && jumpTimer>=0.5f)
        {
            jumpsLeft = numJumps;
        }

        jumpTimer+=Time.fixedDeltaTime;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(jumpsLeft>0)
            {
                rb.velocity = Vector3.zero;
                rb.AddForce(Vector3.up * jumpForce);
                jumpsLeft--;
                jumpTimer =0;
            }
        }
    }
}
