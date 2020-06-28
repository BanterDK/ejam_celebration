using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float timer;
    public int diskCount = 5;

    public CharInput playerRef;

    [Header("FloppyDisk spawns")]
    public List<GameObject> spawnPoints = new List<GameObject>();
    List<GameObject> spawnPointsBackup;

    [Header("Container Hookups")]
    public GameObject spawnContainer;

    [Header("Prefab Hookups")]
    public GameObject[] floppyDisk_prefab;

    [Header("Sound")]
    public AudioSource vo_AudioSource;
    public AudioSource sound_AudioSource;
    public AudioClip[] music;
    private int currentSong = -1;

    // Start is called before the first frame update
    void Awake()
    {
        spawnPointsBackup = new List<GameObject>(spawnPoints);

        int spawnLocID;
        //TO DO : Limit spawn total & Attach colliders to items
        for (int i = 0; i < floppyDisk_prefab.Length; i++)
        {
            spawnLocID = Random.Range(0, spawnPoints.Count);
            spawnFloppyDisk(floppyDisk_prefab[i], i, spawnLocID);
            spawnPoints.RemoveAt(spawnLocID);
        }
    }

    public void spawnFloppyDisk(GameObject disk, int diskID, int spawnLocID)
    {
        GameObject go = Instantiate(floppyDisk_prefab[diskID], spawnPoints[spawnLocID].transform);

        //Give Disk manager reference
        FloppyDisk diskReference = go.GetComponent<FloppyDisk>();
        diskReference.gameManager = this;
        diskReference.playerRef = playerRef;
    }

    public void music_Change()
    {
        currentSong++;
        AudioClip music_clip = music[currentSong];
        sound_AudioSource.clip = music_clip;
        sound_AudioSource.Play();
    }

    private void Start()
    {
        vo_AudioSource = playerRef.gameObject.GetComponent<AudioSource>();
        sound_AudioSource = GetComponent<AudioSource>();
        music_Change();
    }


    // Update is called once per frame
    void Update()
    {

    }
}
