using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move() {
        // Move boss enemy up and down
        transform.position = new Vector2(transform.position.x, Mathf.PingPong(Time.time * speed, 4) - 2);
        
    }
}
