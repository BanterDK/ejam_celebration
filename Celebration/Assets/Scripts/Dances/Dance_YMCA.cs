﻿using System.Collections;
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

    public Vector3 generateAndCalculatePath(Vector2 xRange, Vector2 yRange, Vector2 zRange)
    {
        throw new System.NotImplementedException();
    }

    public void Dance()
    {
        for (int i = 0; i < agentsList.Count; i++)
        {
            if (agentsList[i].GetPathDistRemaining() <= 1f)
            {
                /// this sets the destination of each NavAgent, more sophisticated algorithm wrapper should be made to add areas limits 
                agentsList[i].SetDest(new Vector3(AgentFormationPositions[i].x, 0, AgentFormationPositions[i].y));
                //agentsList[i].SetDest(generateAndCalculatePath());
            }
        }
    }

    void generateAgentFormationPositions(int agents)
    {
        float X = -15;
        float Z = 0;
        float paddingX = 0.75f;
        float paddingY = 1f;
        int rankSize = 5;

        /// loop through every agent and generate a X and Z coord, Colls and Rows
        for (int i = 0; i < agents; i++)
        {
            AgentFormationPositions[i].x = X;
            AgentFormationPositions[i].y = Z;

            X += paddingX;
            if (i % rankSize == 0 && i != 0)
            {
                X -= (paddingX * rankSize);
                Z += paddingY;
            }
        }
    }

    public void Setup(NavAgent agent)
    {
        throw new System.NotImplementedException();
    }
}
