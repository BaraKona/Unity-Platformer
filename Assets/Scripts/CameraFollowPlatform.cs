using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlatform : MonoBehaviour
{
    // Transform because we want camera to match the transform of the player
    public Transform target; // what the camera is following
    float smoothing = 5; // how smooth the camera is going to be
    Vector3 offset; // the difference between the camera and the player
    float lowY; // the lowest y value the camera can go to

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
        lowY = transform.position.y;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + offset; // the position the camera wants to be in
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime); // move the camera to the target position
        if (transform.position.y < lowY) {
            transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
        }
    }
}
