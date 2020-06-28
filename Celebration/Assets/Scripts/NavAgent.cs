using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavAgent : MonoBehaviour
{
    NavMeshAgent agent;
    public iDance CurrentDanceMode = null;
    public List<Collider> AreasAllowed = new List<Collider>();


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        if (agent.path.corners.Length >= 2) { 
            for (int i = 0; i < agent.path.corners.Length - 1; ++i)
            {
                Debug.DrawLine(agent.path.corners[i], agent.path.corners[i+1], Color.green);
            }
        }
    }

    public float GetPathDistRemaining()
    {
        return agent.remainingDistance;
    }

    public void SetDest(Vector3 Dest)
    {
        agent.SetDestination(Dest);
    }
}
