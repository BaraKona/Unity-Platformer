using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float enemyDamage;
    public float damageRate;
    public float pushBackForce; // pushes the player back when hit
    
    float nextDamage; // time until next damage

    // Start is called before the first frame update
    void Start()
    {
        nextDamage = Time.time; 

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && nextDamage < Time.time)
        {
        Debug.Log("EnemyDamage: OnTriggerStay2D");
            PlayerHealth thePlayerHealth = other.gameObject.GetComponent<PlayerHealth>();
            thePlayerHealth.TakeDamage(enemyDamage);
            nextDamage = Time.time + damageRate;

            PushBack(other.transform);
        }
    }
    void PushBack (Transform pushedObject) {
        Vector2 pushDirection = new Vector2(0, (pushedObject.position.y - transform.position.y)).normalized;
        pushDirection *= pushBackForce;
        Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        pushRB.velocity = Vector2.zero;
        pushRB.AddForce(pushDirection, ForceMode2D.Impulse);
    }
}
