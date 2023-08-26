using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawner : MonoBehaviour
{
    [SerializeField] private bool sceneRespawn;
    [SerializeField] private int currentScene;

    [SerializeField] private int respawnPoint;
    [SerializeField] private Transform[] respawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   private void OnTriggerEnter2D(Collider2D other) 
   {
     if(other.gameObject.tag == "Respawn" && sceneRespawn == true)
     {
        SceneManager.LoadScene(currentScene);
     }
     if(other.gameObject.tag =="Respawn" && sceneRespawn == false)
     {
        gameObject.transform.position = respawnPoints[respawnPoint].position;
     }
   }
}
