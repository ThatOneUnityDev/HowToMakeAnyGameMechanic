using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private LayerMask interactLayer;

    [SerializeField] private float radius;
    [SerializeField] private int explosionForce;
    [SerializeField] private float explosionTime;
    [SerializeField] private GameObject explosionPrefab;

    private float explosionTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        explosionTimer += Time.fixedDeltaTime;

        if(explosionTimer >= explosionTime)
        {
            // do our explosion

            Collider2D[] collisions = Physics2D.OverlapCircleAll(transform.position,radius,interactLayer);

            foreach(Collider2D coll in collisions)
            {
                if(coll.TryGetComponent<Rigidbody2D>(out Rigidbody2D rb))
                {
                    Vector3 dir = rb.transform.position - transform.position;
                    rb.AddForce(dir.normalized * explosionForce);
                }
            }
            
            // spawn explosion effects
            Instantiate(explosionPrefab,transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
