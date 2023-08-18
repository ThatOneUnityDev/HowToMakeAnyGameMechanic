using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private int moveSpeed;

    public bool useTransformMovement;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        if(useTransformMovement == false)
        {
            rb.velocity = new Vector3(x, rb.velocity.y, 0);
        }
        else
        {
            transform.position = new Vector3(transform.position.x + x * Time.deltaTime * moveSpeed, 
            transform.position.y, transform.position.z);
        }
       
    }
}
