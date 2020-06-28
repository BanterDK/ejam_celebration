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
    public int spawnCount;
    public List<int> randomInt = new List<int>();   //  Declare list

    [Header("Container Hookups")]
    public GameObject spawnContainer;

    [Header("Prefab Hookups")]
    public GameObject floppyDisk_prefab;
    

    // Start is called before the first frame update
    void Awake()
    {

        for (int n = 0; n < (diskCount+1); n++)    //  Populate list
        {
            randomInt.Add(n);
        }
        int index = Random.Range(1, randomInt.Count - 1);    //  Pick random element from the list
        int seed = randomInt[index];    //  i = the number that was randomly picked
        randomInt.RemoveAt(index);   //  Remove chosen element


        spawnPoints = new List<GameObject>();
        spawnCount = spawnContainer.transform.childCount;


        //TO DO : Limit spawn total & Attach colliders to items
        for (int i = 0; i < spawnCount; i++)
        {
            spawnPoints.Add(spawnContainer.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < spawnCount; i++)
        {
            Instantiate(floppyDisk_prefab, spawnPoints[0].transform);

            //Give Disk manager reference
            FloppyDisk diskReference = spawnPoints[0].transform.GetChild(0).GetComponent<FloppyDisk>();
            diskReference.gameManager = this;
            diskReference.playerRef = playerRef;
            

            //Spawn Cleanup
            spawnPoints.Remove(spawnPoints[0]);
        }

    }


// Update is called once per frame
void Update()
    {

    }
}
