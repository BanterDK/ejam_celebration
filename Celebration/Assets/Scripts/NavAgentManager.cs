using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavAgentManager : MonoBehaviour
{
    [SerializeField]
    List<NavAgent> agentsList = new List<NavAgent>();
    //[SerializeField]
    public iDance CurrentDanceMode;

    // Start is called before the first frame update
    void Start()
    {
        agentsList.AddRange(FindObjectsOfType<NavAgent>());
        //CurrentDanceMode = gameObject.AddComponent<Dance_RandomMove>();
        CurrentDanceMode = gameObject.AddComponent<Dance_YMCA>();
        CurrentDanceMode.Setup(agentsList);
    }

    // Update is called once per frame
    void Update()
    {
        CurrentDanceMode.dance(agentsList);
    }
}
