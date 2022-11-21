using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalPost : MonoBehaviour
{
    // Start is called before the first frame update
    public string levelToLoad;
    void Start()
    {
        // levelToLoad = Application.loadedLevel+1; 
        
    }

    
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            Debug.Log("Player collided");
            SceneManager.LoadScene(levelToLoad);
        }
    }
    void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            Debug.Log("Player collided");
            SceneManager.LoadScene(levelToLoad);
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
