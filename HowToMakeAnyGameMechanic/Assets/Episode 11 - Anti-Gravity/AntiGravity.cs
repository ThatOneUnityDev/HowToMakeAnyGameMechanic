using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiGravity : MonoBehaviour
{
    [SerializeField] private bool isGrounded;
    [SerializeField] private Transform groundRayTransform;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private float gravityScale;
    [SerializeField] private Transform playerVisual;

    private Rigidbody2D rb;
    private bool isFlipped;
    private Vector3 playerVisualScale;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;
        playerVisualScale = playerVisual.localScale;
    }

    private void FixedUpdate() 
    {
        isGrounded = Physics2D.Linecast(transform.position,groundRayTransform.position,groundLayer);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && isGrounded == true)
        {
            if(isFlipped == false)
            {
                rb.gravityScale = -gravityScale;
                playerVisual.localScale = new Vector3(playerVisualScale.x,-playerVisualScale.y,playerVisualScale.z);
            }
            else
            {
                rb.gravityScale = gravityScale;
                playerVisual.localScale = playerVisualScale;
            }
            isFlipped = !isFlipped;
        }
    }
}
