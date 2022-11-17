using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 10f;
    Transform target;
    public float playerDistance;
    bool seen = false;
    // Start is called before the first frame update
    void Start()
    {
        // enemy will move towards the player
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        // enemy movement 
    }

    // Update is called once per frame
    void Update()
    {

         // play the enemyReceiveDamage animation
        Move();
    }
    void Move () {
        // if player is close
        if (Vector2.Distance(transform.position, target.position) < playerDistance) {
            seen = true;
        }
        // if player has been seen
        if (seen) {
            // move towards player
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
