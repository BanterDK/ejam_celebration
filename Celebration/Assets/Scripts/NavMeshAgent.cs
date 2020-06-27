using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgent : MonoBehaviour
{
    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        //SetDest();
        //agent.destination = new Vector3(0, 10, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.LogError("hello");
        //gameObject.GetComponent<NavMeshAgent>()
    }

    public void SetDest(Vector3 Dest)
    {
        agent.
    }
}
