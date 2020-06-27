using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dance_RandomMove : MonoBehaviour, iDance
{
    private List<NavAgent> agentsList;

    //public Dance_RandomMove(List<NavAgent> agentsList)
    //{
    //    this.agentsList = agentsList;
    //}

    public void Setup(List<NavAgent> agentsList)
    {
        this.agentsList = agentsList;
    }

    public void dance(List<NavAgent> agentsList)
    {

        for (int i = 0; i < agentsList.Count; i++)
        {
            if (agentsList[i].GetPathDistRemaining() <= 1f)
            {
                /// this sets the destination of each NavAgent, more sophisticated algorithm wrapper should be made to add areas limits 
                agentsList[i].SetDest(new Vector3(Random.Range(-20, 20), 0, Random.Range(-20, 20)));
            }
        }
    }


}
