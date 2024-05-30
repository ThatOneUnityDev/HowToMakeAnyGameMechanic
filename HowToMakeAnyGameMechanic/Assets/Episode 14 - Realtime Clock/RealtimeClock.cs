using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class RealtimeClock : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI clockText;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateClock",0,1);
    }


    public void UpdateClock()
    {
        clockText.text = DateTime.Now.ToString("hh:mm:ss:tt");
    }
}
