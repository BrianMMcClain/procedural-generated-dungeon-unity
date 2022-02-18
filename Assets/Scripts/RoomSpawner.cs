using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public GameObject nWallSpawn;
    public GameObject sWallSpawn;
    public GameObject eWallSpawn;
    public GameObject wWallSpawn;

    private GameObject nWall;
    private GameObject sWall;
    private GameObject eWall;
    private GameObject wWall;

    public GameObject fullWallPrefab;

    void Start()
    {
    
    }

    public void SpawnWalls(bool n, bool s, bool e, bool w)
    {
        nWallSpawn = transform.Find("Wall North Spawn").gameObject;
        sWallSpawn = transform.Find("Wall South Spawn").gameObject;
        eWallSpawn = transform.Find("Wall East Spawn").gameObject;
        wWallSpawn = transform.Find("Wall West Spawn").gameObject;

        if (n) { Instantiate(fullWallPrefab, nWallSpawn.transform); }
        if (s) { Instantiate(fullWallPrefab, sWallSpawn.transform); }
        if (e) { Instantiate(fullWallPrefab, eWallSpawn.transform); }
        if (w) { Instantiate(fullWallPrefab, wWallSpawn.transform); }
    }

    void Update()
    {
        
    }
}
