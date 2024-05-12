using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private const string RAISE_PARAM = "Raise";
   
   private void OnTriggerEnter2D(Collider2D other) 
   {
        if(other.gameObject.tag == "Player")
        {
            anim.SetTrigger(RAISE_PARAM);
        }
   }
}
