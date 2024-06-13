using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pitcher : MonoBehaviour
{
    [SerializeField] private Transform crosshair;
    [SerializeField] private Transform bat;

    [SerializeField] private float batPitchRotOffset = 20;
    [SerializeField] private float batSwungRotOffset = 90;

    [SerializeField] private float batSwungPosOffset = 1;

    [SerializeField] private int maxBallForce;
    [SerializeField] private Slider ballForceSlider;

    [SerializeField] private GameObject ballPrefab;

    private Vector3 batDir;
    private bool swung;
    private Vector3 batPitchPos;
    private Vector3 batSwungPos;
    private int ballForce;
    // Start is called before the first frame update
    void Start()
    {
        batPitchPos = bat.localPosition;
        batSwungPos = new Vector3(batPitchPos.x + batSwungPosOffset, batPitchPos.y,batPitchPos.z);
        ballForceSlider.maxValue = maxBallForce;
    }

    // Update is called once per frame
    void Update()
    {
        batDir = crosshair.position - bat.position;
        bat.transform.right = batDir;
        Vector3 batRot = bat.transform.rotation.eulerAngles;
        if (swung == false)
        {
            bat.rotation = Quaternion.Euler(batRot.x, batRot.y, batRot.z + batPitchRotOffset);
            bat.localPosition = batPitchPos;
        }
        else
        {
            bat.rotation = Quaternion.Euler(batRot.x, batRot.y, batRot.z - batSwungRotOffset);
            bat.localPosition = batSwungPos;
        }

        if (Input.GetMouseButtonDown(0))
        {
            swung = !swung;

            if(swung == true)
            {
               GameObject ball = Instantiate(ballPrefab,bat.position,Quaternion.identity);
               ball.TryGetComponent<Rigidbody2D>(out Rigidbody2D rb);
               rb.AddForce(batDir.normalized * ballForce);
            }
        }
    }

    private void FixedUpdate() 
    {
        ballForce = Mathf.Abs(Mathf.RoundToInt(Mathf.Sin(Time.time) * maxBallForce));
        ballForceSlider.value = ballForce;
    }
}
