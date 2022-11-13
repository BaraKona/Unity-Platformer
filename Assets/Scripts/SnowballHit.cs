using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballHit : MonoBehaviour
{
    public float weaponDamage;

    // make a reference to the projectile controller script
    ProjectileController projectileController;

    
    void Awake()
    {
        // get a reference to the projectile controller script from the parent
        projectileController = GetComponentInParent<ProjectileController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        // if the object we hit is an enemy

        if (other.gameObject.layer == LayerMask.NameToLayer("Hitable")) {
            Debug.Log("Hit enemy");
            if (other.tag == "Enemy") {
            // get a reference to the enemy health script
                EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
                // call the enemy's damage function
                enemyHealth.addDamage(weaponDamage);
            }
            // destroy the projectile
            projectileController.removeForce();
            Destroy(gameObject);
        }
    }
    // destroy the projectile if it hits a wall but its going too fast
    void OnTriggerStay2D(Collider2D other) {
        // if the object we hit is an enemy
        if (other.gameObject.layer == LayerMask.NameToLayer("Hitable"))  {
            if (other.tag == "Enemy") {
            // get a reference to the enemy health script
                EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
                // call the enemy's damage function
                enemyHealth.addDamage(weaponDamage);
            }
            // destroy the projectile
            projectileController.removeForce();
            Destroy(gameObject);
        }
    }
}
