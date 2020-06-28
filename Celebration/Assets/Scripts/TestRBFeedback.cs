using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRBFeedback : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "AI_Agent")
        {
            Vector3 dir = collision.contacts[0].point - transform.position;
            dir = -dir.normalized * 10;

            rb.AddForce(dir,ForceMode.Impulse);
        }
    }
}
