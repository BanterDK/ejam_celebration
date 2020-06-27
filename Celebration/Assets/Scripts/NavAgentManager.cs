using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavAgentManager : MonoBehaviour
{
    [SerializeField]
    List<NavAgent> agentsList = new List<NavAgent>();
    //[SerializeField]
    //public iDance CurrentDanceMode;

    // Start is called before the first frame update
    void Start()
    {
        agentsList.AddRange(FindObjectsOfType<NavAgent>());
        for (int i = 0; i < agentsList.Count; i++)
        {
            //setAgentCurrentDanceMode()
        }
    }

    public void setAgentCurrentDanceMode(NavAgent agent, iDance dance)
    {
        //agent.CurrentDanceMode = gameObject.AddComponent<Dance_RandomMove>();
        //agent.CurrentDanceMode = gameObject.AddComponent<>();
        agent.CurrentDanceMode.Setup(agentsList);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (NavAgent agent in agentsList)
        {
            //agent.CurrentDanceMode.dance(agentsList);
        }
    }


}
