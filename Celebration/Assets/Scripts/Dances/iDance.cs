using System.Collections;
using System.Collections.Generic;

public interface iDance
{
    //public int abc { get; set; } = 1;

    /// <summary>
    /// Common dance function so NavAgentManager can call current dance, more efficent that lots of if statements checking current dance to run correct code.
    /// All Dance code for setting final destination in here!
    /// </summary>
    /// <param name="agentsList"></param>
    void dance(List<NavAgent> agentsList);

    void Setup(List<NavAgent> agentsList);
}
