using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public GameObject nWallSpawn;
    public GameObject sWallSpawn;
    public GameObject eWallSpawn;
    public GameObject wWallSpawn;

    public GameObject fullWallPrefab;

    void Start()
    {
        nWallSpawn = transform.Find("Wall North Spawn").gameObject;
        sWallSpawn = transform.Find("Wall South Spawn").gameObject;
        eWallSpawn = transform.Find("Wall East Spawn").gameObject;
        wWallSpawn = transform.Find("Wall West Spawn").gameObject;

        Instantiate(fullWallPrefab, nWallSpawn.transform);
        Instantiate(fullWallPrefab, sWallSpawn.transform);
        Instantiate(fullWallPrefab, eWallSpawn.transform);
        Instantiate(fullWallPrefab, wWallSpawn.transform);
    }

    void Update()
    {
        
    }
}
