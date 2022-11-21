using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathInducer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        void OnTriggerEnter2D(Collider2D other) {
        // if the object is hit by the player, kill the player
        if (other.gameObject.tag == "Player") {
            // get a reference to the player health script
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            // call the player's damage function
            playerHealth.TakeDamage(100);
        }
        }
}
