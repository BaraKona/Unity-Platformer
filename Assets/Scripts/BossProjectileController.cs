using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectileController : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float spikeSpeed;
    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce(new Vector2(-1, 0) * spikeSpeed, ForceMode2D.Impulse);;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
