using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloppyDisk : MonoBehaviour
{
    [Header("Stats")]
    public bool canBePickedUp;
    public int itemNumber;

    [Header("References")]
    public GameManager gameManager;
    public CharInput playerRef;

    //[Header("Effects")]
    //ParticleSystem

    // Start is called before the first frame update
    void Update()
    {

    }

    public void pickupAvailable(bool a)
    {
        canBePickedUp = a;
        playerRef.canPickUp = a;
        playerRef.pickupID = gameObject;
    }

    private void OnTriggerEnter(Collider c)
    {
        if(c.tag == "Player")
            pickupAvailable(true);
    }

    private void OnTriggerExit(Collider c)
    {
        if (c.tag == "Player")
            pickupAvailable(false);
    }




}


