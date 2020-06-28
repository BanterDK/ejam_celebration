using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float timer;
    public int diskCount = 5;

    private List<GameObject> spawnPoints;
    public CharInput playerRef;

    [Header("Counters")]
    public List<int> randomInt = new List<int>();   //  Declare list

    [Header("Container Hookups")]
    public GameObject spawnContainer;

    [Header("Prefab Hookups")]
    public GameObject[] floppyDisk_prefab;
    

    // Start is called before the first frame update
    void Awake()
    {
        spawnPoints = new List<GameObject>();
        //TO DO : Limit spawn total & Attach colliders to items
        for (int i = 0; i < spawnContainer.transform.childCount; i++)
        {
            spawnPoints.Add(spawnContainer.transform.GetChild(i).gameObject);
        }

        //TO DO
        //Randomizer
        for (int n = 0; n < diskCount; n++)    //  Populate list
        {
            randomInt.Add(n);
        }
        int index = Random.Range(1, randomInt.Count);    //  Pick random element from the list
        int seed = randomInt[index];    //  i = the number that was randomly picked
        randomInt.RemoveAt(index);   //  Remove chosen element

        for (int i = 0; i < diskCount; i++)
        {

            //spawnPoints[i] is the index of spawnpoint in the list
            GameObject go = Instantiate(floppyDisk_prefab[i], spawnPoints[i].transform);

            //Give Disk manager reference
            FloppyDisk diskReference = go.GetComponent<FloppyDisk>();
            diskReference.gameManager = this;
            diskReference.playerRef = playerRef;
            

            //Spawn Cleanup
            //spawnPoints.Remove(spawnPoints[0]);
        }

    }


// Update is called once per frame
void Update()
    {

    }
}
