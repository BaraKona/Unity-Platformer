using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyShoot : MonoBehaviour
{
    public GameObject arrow;
    public float shootTime;
    public Transform arrowSpawner;
    public Transform arrowSpawner1;
    public Transform arrowSpawner2;
    public Transform arrowSpawner3;
    public Transform arrowSpawner4;
    public Transform arrowSpawner5;
    public Transform arrowSpawner6;

    Transform target;
    public float arrowTime;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }

    void OnTriggerStay2D(Collider2D other) {
    }
    // Update is called once per frame
    void Update()
    {
        if (target && arrowTime < Time.time) {
            Debug.Log("BossEnemyShoot: OnTriggerStay2D");
            if (Time.time > arrowTime) {
            arrowTime = Time.time + shootTime;
            Instantiate(arrow, arrowSpawner.position, Quaternion.identity);
            Instantiate(arrow, arrowSpawner1.position, Quaternion.identity);
            Instantiate(arrow, arrowSpawner2.position, Quaternion.identity);
            Instantiate(arrow, arrowSpawner3.position, Quaternion.identity);
            Instantiate(arrow, arrowSpawner4.position, Quaternion.identity);
            Instantiate(arrow, arrowSpawner5.position, Quaternion.identity);
            Instantiate(arrow, arrowSpawner6.position, Quaternion.identity);

            }
            // shootTime = 0;
        }
        
    }
}
