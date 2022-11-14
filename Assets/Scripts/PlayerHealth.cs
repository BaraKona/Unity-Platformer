using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float playerFullHealth;
    float playerCurrentHealth;
    Animator anim;
    // plater controller
    PlayerController controller;

    //HUD Variables
    public Slider healthBar;
    public Slider floatingHealthBar;

    void Start()
    {
        playerCurrentHealth = playerFullHealth;
        controller = GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
        //HUD initialization
        healthBar.maxValue = playerFullHealth;
        healthBar.value = playerFullHealth;
        floatingHealthBar.maxValue = playerFullHealth;
        floatingHealthBar.value = playerFullHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damage)
    {
        if (damage <= 0) return;
        anim.SetTrigger("playerReceiveDamage");
        playerCurrentHealth -= damage;
        //HUD update
        healthBar.value = playerCurrentHealth;
        floatingHealthBar.value = playerCurrentHealth;
        if (playerCurrentHealth <= 0)
        {
            MakeDead();
        }
    }
    public void MakeDead()
    {
        controller.enabled = false;
        Destroy(gameObject);
    }
}
