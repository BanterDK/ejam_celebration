using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavAgentAreaLimit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool checkBoundsForDest(Collider collider, Vector3 point)
    {
        if (collider.bounds.Contains(point))
        {
            Debug.Log("In Bounds");
            return true;
        }
        return false;
    }
}
