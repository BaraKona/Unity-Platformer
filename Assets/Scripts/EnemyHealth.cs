using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float enemyMaxHealth;
    float currentHealth;
    public Slider enemySlider;

    Animator anim;

    void Start()
    {
        currentHealth = enemyMaxHealth;
        enemySlider.maxValue = enemyMaxHealth;
        enemySlider.value = enemyMaxHealth;

        if (gameObject.name == "BoxEnemy") {
            anim = GetComponent<Animator>();
        }
        // anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addDamage(float damage) {
        enemySlider.gameObject.SetActive(true);
        currentHealth -= damage; // subtract damage from current health
        enemySlider.value = currentHealth; // update slider
        if (gameObject.name == "BoxEnemy") {
            anim.SetTrigger("enemyReceiveDamage");
        } // play the enemyReceiveDamage animation
        if (currentHealth <= 0) {
            makeDead();
        }
    }
    void makeDead() {
        Destroy(gameObject);
    }
}
