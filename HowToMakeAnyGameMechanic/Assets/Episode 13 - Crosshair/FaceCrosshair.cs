using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCrosshair : MonoBehaviour
{
    [SerializeField] private Transform crosshair;
    private Vector3 scale;
    // Start is called before the first frame update
    void Start()
    {
        scale = gameObject.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(crosshair.position.x > transform.position.x)
        {
            gameObject.transform.localScale = scale;
        }
        else
        {
            gameObject.transform.localScale = new Vector3(-scale.x,scale.y,scale.z);
        }
    }
}
