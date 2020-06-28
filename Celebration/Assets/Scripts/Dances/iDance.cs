using System.Collections.Generic;
using UnityEngine;
public interface iDance
{
    /// <summary>
    /// Used for Area Limiting
    /// Generate point for agent to travel too and calulate path here
    /// </summary>
    Vector3 generateAndCalculatePath(Vector2 xRange, Vector2 yRange, Vector2 zRange);

    /// <summary>
    /// Common dance function so NavAgentManager can call current dance, more efficent that lots of if statements checking current dance to run correct code.
    /// All Dance code for setting final destination in here!
    /// </summary>
    /// 
    void Dance();

    void Setup(NavAgent agent);
    void Setup(List<NavAgent> agentsList);
}
