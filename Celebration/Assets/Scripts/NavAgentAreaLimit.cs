using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavAgentAreaLimit : MonoBehaviour
{
    public Vector3 generatePointInsideArea(NavAgent agent, iDance script)
    {
        int areaIndex = Random.Range(0, agent.AreasAllowed.Count);
        Vector2 xRange = new Vector2((agent.AreasAllowed[areaIndex].transform.position.x - agent.AreasAllowed[areaIndex].gameObject.GetComponent<Collider>().bounds.extents.x), (agent.AreasAllowed[areaIndex].transform.position.x + agent.AreasAllowed[areaIndex].gameObject.GetComponent<Collider>().bounds.extents.x));
        Vector2 yRange = new Vector2((agent.AreasAllowed[areaIndex].transform.position.y - agent.AreasAllowed[areaIndex].gameObject.GetComponent<Collider>().bounds.extents.y), (agent.AreasAllowed[areaIndex].transform.position.y + agent.AreasAllowed[areaIndex].gameObject.GetComponent<Collider>().bounds.extents.y));
        Vector2 zRange = new Vector2((agent.AreasAllowed[areaIndex].transform.position.z - agent.AreasAllowed[areaIndex].gameObject.GetComponent<Collider>().bounds.extents.z), (agent.AreasAllowed[areaIndex].transform.position.z + agent.AreasAllowed[areaIndex].gameObject.GetComponent<Collider>().bounds.extents.z));

        Vector3 point = script.generateAndCalculatePath(xRange, yRange, zRange);
        return point;
    }
}
