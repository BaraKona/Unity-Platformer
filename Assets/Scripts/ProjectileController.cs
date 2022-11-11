using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float snowballSpeed = 10f;
    // Awake is called when object comes to life
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        // apply force as soon as object comes to life
        if(transform.localRotation.z > 0) {
            rb2d.AddForce(new Vector2(1, 0) * snowballSpeed, ForceMode2D.Impulse);
        } else {
            rb2d.AddForce(new Vector2(-1, 0) * snowballSpeed, ForceMode2D.Impulse);
        }
        
        // destroy object after 10 seconds
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // destroy object if it hits a wall
    public void removeForce() {
        rb2d.velocity = new Vector2(0, 0);
    }
}
