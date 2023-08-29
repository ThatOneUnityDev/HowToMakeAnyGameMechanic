using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectibleScript : MonoBehaviour
{
    [SerializeField] private int coins;
    [SerializeField] private TextMeshProUGUI coinDisplay;
   private void OnTriggerEnter2D(Collider2D other) 
   {
        if(other.gameObject.tag == "Collectible")
        {
          coins++;
          Destroy(other.gameObject);
          coinDisplay.text = coins.ToString();
        }
   }
}
