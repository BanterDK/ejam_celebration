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

    bool forceUpdate = false;
    void Start()
    {
        agentManager = FindObjectOfType<NavAgentManager>();
        thisAgent = gameObject.GetComponent<NavAgent>();
        anim = gameObject.GetComponent<Animator>();

        updateState(States.Walk);
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 1000) <= 1)
        {
            if ((thisAgent.IsCurrentlyMoving() == false && currentState != States.Die && currentState != States.YMCA) || forceUpdate == true)
            {
                Debug.Log("updateState");
                forceUpdate = false;
                updateState((States)Random.Range(0, 4));
            }
        }
    }

    public IEnumerator forceUpdateState(int stateToUpdateTo)
    {
        yield return new WaitUntil(() => thisAgent.IsCurrentlyMoving() == false);
            forceUpdate = true;
            //updateState((States)stateToUpdateTo);
    }

    void removeOldState()
    {
        switch (currentState)
        {
            case States.Macarena:
                Destroy(gameObject.GetComponent<Dance_Dance>());
                break;
            case States.Wave:
                Destroy(gameObject.GetComponent<Dance_Dance>());
                break;
            case States.Gabber:
                Destroy(gameObject.GetComponent<Dance_Dance>());
                break;
            case States.Walk:
                Destroy(gameObject.GetComponent<Dance_RandomMove>());
                break;
            default:
                break;
        }
    }

    void updateState(States stateToUpdateTo)
    {
        removeOldState();
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
        Debug.Log(currentState);
    }
}
