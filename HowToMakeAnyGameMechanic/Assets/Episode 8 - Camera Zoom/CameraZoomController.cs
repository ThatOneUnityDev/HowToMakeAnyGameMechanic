using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomController : MonoBehaviour
{
    [SerializeField] private GameObject zoomInCam;
    [SerializeField] private GameObject zoomOutCam;

    [SerializeField] private bool zoomedOut;
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "ZoomOut")
        {
            zoomInCam.SetActive(false);
            zoomOutCam.SetActive(true);
            zoomedOut = true;
        }

        if (other.gameObject.tag == "ZoomIn")
        {
            zoomInCam.SetActive(true);
            zoomOutCam.SetActive(false);
            zoomedOut = false;
        }
    }
}
