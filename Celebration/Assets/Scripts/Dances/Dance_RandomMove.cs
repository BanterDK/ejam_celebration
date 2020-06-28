using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dance_RandomMove : MonoBehaviour, iDance
{
    NavAgent agent;
    NavAgentAreaLimit navAgentAreaLimit;

    public void Setup(NavAgent agent)
    {
        this.agent = agent;
        navAgentAreaLimit = FindObjectOfType<NavAgentAreaLimit>();
    }

    public Vector3 generateAndCalculatePath(Vector2 xRange, Vector2 yRange, Vector2 zRange)
    {
        return new Vector3(Random.Range(xRange.x, xRange.y), 0, Random.Range(zRange.x, zRange.y));
    }

    public void Dance()
    {
        if (agent.GetPathDistRemaining() <= 1f)
        {
            /// this sets the destination of each NavAgent, more sophisticated algorithm wrapper should be made to add areas limits

            //this.StartCoroutine(
            agent.SetDest(navAgentAreaLimit.generatePointInsideArea(agent, this));
            //);

            NavAgentState s = agent.GetComponent<NavAgentState>();
            this.StartCoroutine(s.forceUpdateState(Random.Range(0, 3))); 
        }
    }

    public void Setup(List<NavAgent> agentsList)
    {
        throw new System.NotImplementedException();
    }
}
