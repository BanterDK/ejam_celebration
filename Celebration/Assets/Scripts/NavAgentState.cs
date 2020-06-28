using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavAgentState : MonoBehaviour
{
    // Start is called before the first frame update
    public enum States{
        Macarena,
        Wave,
        Gabber,
        Walk,
        YMCA,
        Die
    };

    public States currentState = States.Walk;

    NavAgentManager agentManager;
    NavAgent thisAgent;
    Animator anim;

    void Start()
    {
        agentManager = FindObjectOfType<NavAgentManager>();
        thisAgent = gameObject.GetComponent<NavAgent>();
        anim = gameObject.GetComponent<Animator>();

        //updateState(States.Macarena);
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 100) <= 5)
        {
            if (thisAgent.IsCurrentlyMoving() == false)
            {
                updateState((States)Random.Range(0, 4));
            }
        }
    }

    void updateState(States stateToUpdateTo)
    {
        currentState = stateToUpdateTo;
        anim.SetTrigger(stateToUpdateTo.ToString());
        switch (stateToUpdateTo)
        {
            case States.Macarena:
                agentManager.setAgentCurrentDanceModeDance_Dance(thisAgent);
                break;

            case States.Wave:
                agentManager.setAgentCurrentDanceModeDance_Dance(thisAgent);
                break;

            case States.Gabber:
                agentManager.setAgentCurrentDanceModeDance_Dance(thisAgent);
                break;

            case States.Walk:
                agentManager.setAgentCurrentDanceModeDance_RandomMove(thisAgent);
                break;

            case States.YMCA:
                agentManager.setAgentCurrentDanceModeDance_YMCA(thisAgent);
                break;

            case States.Die:
                break;

            default:
                break;
        }
    }
}
