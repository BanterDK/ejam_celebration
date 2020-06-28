using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowLock : MonoBehaviour
{
    public Transform target;
    private Rigidbody2D targetRigidbody;
    public Vector3 zOffset = new Vector3(0, 0, -10);
    private Vector3 xyOffset = Vector3.zero;
    public float lerpFactor = 0.5f;


    public float maxSpeed = 5f;
    public float maxOffset = 2f;
    private Vector3 oldPos;

    private void Start()
    {
        //oldPos = target.position;
        targetRigidbody = target.GetComponent<Rigidbody2D>();
    }



    // Update is called once per frame
    void Update()
    {
        //Compute targets velocity
        Vector3 velocity = targetRigidbody.velocity;
        //oldPos = target.position;

        //Move camera in front of target proportional to velocity
        //Vector3 xyOffset = velocity * maxOffset / maxSpeed;
        xyOffset = Vector3.Lerp(xyOffset, velocity * maxOffset / maxSpeed, 1 - Mathf.Pow(1 - lerpFactor, Time.deltaTime));
        transform.position = target.transform.position + xyOffset + zOffset;
    }
}
