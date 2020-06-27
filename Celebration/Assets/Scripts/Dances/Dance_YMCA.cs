using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dance_YMCA : MonoBehaviour, iDance
{
    private List<NavAgent> agentsList;

    /// <summary>
    /// X and Z array of positions for agents travel too
    /// </summary>
    Vector2[] AgentFormationPositions;

    public void Setup(List<NavAgent> agentsList)
    {
        this.agentsList = agentsList;
        AgentFormationPositions = new Vector2[agentsList.Count];
        generateAgentFormationPositions(agentsList.Count);
    }

    public void dance()
    {
        for (int i = 0; i < agentsList.Count; i++)
        {
            if (agentsList[i].GetPathDistRemaining() <= 1f)
            {
                /// this sets the destination of each NavAgent, more sophisticated algorithm wrapper should be made to add areas limits 
                //agentsList[i].SetDest(new Vector3(Random.Range(-20, 20), 0, Random.Range(-20, 20)));
                agentsList[i].SetDest(new Vector3(AgentFormationPositions[i].x, 0, AgentFormationPositions[i].y));
            }
        }
    }

    void generateAgentFormationPositions(int agents)
    {
        int agentIndex = 0;
        int X = 0;
        int Z = 0;
        int padding = 2;

        /// loop through every agent and generate a X and Z coord, Colls and Rows
        for (int i = 0; i < agents; i++)
        {
            AgentFormationPositions[agentIndex].x = X;
            AgentFormationPositions[agentIndex].y = Z;
            X += padding;
            Z += padding;
            agentIndex++;
        }
    }
}
