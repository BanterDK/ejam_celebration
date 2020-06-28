using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dance_RandomMove : MonoBehaviour, iDance
{
    private List<NavAgent> agentsList;
    NavAgentAreaLimit navAgentAreaLimit = new NavAgentAreaLimit();

    public void Setup(List<NavAgent> agentsList)
    {
        this.agentsList = agentsList;
    }

    public Vector3 generateAndCalculatePath(Vector2 xRange, Vector2 yRange, Vector2 zRange)
    {
        return new Vector3(Random.Range(xRange.x, xRange.y), 0, Random.Range(zRange.x, zRange.y));
    }

    public void Dance()
    {

        for (int i = 0; i < agentsList.Count; i++)
        {
            if (agentsList[i].GetPathDistRemaining() <= 1f)
            {
                /// this sets the destination of each NavAgent, more sophisticated algorithm wrapper should be made to add areas limits

                //agentsList[i].SetDest(new Vector3(Random.Range(-20, 20), 0, Random.Range(-20, 20)));
                agentsList[i].SetDest(navAgentAreaLimit.generatePointInsideArea(gameObject.GetComponent<NavAgent>(), this));
                
            }
        }
    }
}
