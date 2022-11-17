using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyShoot : MonoBehaviour
{
    public GameObject arrow;
    public float shootTime;
    public Transform arrowSpawner;

    public float arrowTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Player" && arrowTime < Time.time) {
            Debug.Log("BossEnemyShoot: OnTriggerStay2D");
            if (Time.time > arrowTime) {
                    arrowTime = Time.time + shootTime;

            Instantiate(arrow, arrowSpawner.position, Quaternion.identity);
                }
            // shootTime = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
