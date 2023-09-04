using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InAirDash : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private bool isGrounded;
    [SerializeField] private Transform groundRayTransform;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private int numDashes;
    [SerializeField] private int dashDuration;
    [SerializeField] private int dashSpeed;


    private int dashesLeft;
    private float dashTimer;
    private bool isDashing;
    Vector3 dashDir;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.Linecast(transform.position,groundRayTransform.position, groundLayer);

        if(isGrounded == true)
        {
            dashesLeft = numDashes;
        }

        if(isDashing == true)
        {
            if(dashTimer>=0)
            {
                rb.velocity = dashDir.normalized * dashSpeed;
                dashTimer -= Time.fixedDeltaTime;
            }
            else
            {
                isDashing = false;
                rb.gravityScale =1;
                rb.velocity = Vector3.zero;
            }
            
        }
    }

    private void Update() 
    {
        float x = Input.GetAxis("Horizontal");

        if(x!=0 && isGrounded == false && rb.velocity.y <=0 && isDashing == false)
        {
            if(dashesLeft>0 && Input.GetKeyDown(KeyCode.Space))
            {
                dashDir = new Vector3(x,0,0);
                rb.velocity = Vector3.zero;
                dashesLeft--;
                isDashing = true;
                rb.gravityScale = 0;
                dashTimer = dashDuration;
            }
        }
    }
}
