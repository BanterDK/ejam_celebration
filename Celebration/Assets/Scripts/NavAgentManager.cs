using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavAgentManager : MonoBehaviour
{
    [SerializeField]
    List<NavAgent> agentsList = new List<NavAgent>();

    // Start is called before the first frame update
    void Start()
    {
        agentsList.AddRange(FindObjectsOfType<NavAgent>());
        for (int i = 0; i < agentsList.Count; i++)
        {
            setAgentCurrentDanceModeDance_YMCA(agentsList[i]);
        }
    }

    /// <summary>
    /// Use to set an agent to RandomMove mode
    /// </summary>
    public void setAgentCurrentDanceModeDance_RandomMove(NavAgent agent)
    {
        agent.CurrentDanceMode = agent.gameObject.AddComponent<Dance_RandomMove>();
        agent.CurrentDanceMode.Setup(agentsList);
    }

    /// <summary>
    /// Use to set an agent to YMCA mode
    /// </summary>
    public void setAgentCurrentDanceModeDance_YMCA(NavAgent agent)
    {
        agent.CurrentDanceMode = agent.gameObject.AddComponent<Dance_YMCA>();
        agent.CurrentDanceMode.Setup(agentsList);
    }

    /// <summary>
    /// Update runs the dance code for every agent
    /// </summary>
    void Update()
    {
        foreach (NavAgent agent in agentsList)
        {
            agent.CurrentDanceMode.Dance();
        }
    }


}
