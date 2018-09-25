using UnityEngine;
using System.Collections;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    

    private int RandomX;
    private int RandomZ;

    public int UpperBoundX;
    public int LowerBoundX;
    public int UpperBoundZ;
    public int LowerBoundZ;

    public float SpawnHeight;

    [SerializeField]
    Behaviour[] ComponentsToEnable;

    System.Random rnd = new System.Random();

    void Start()
    {
        StartCoroutine(SpawnWaves());
        //SpawnPlayer();
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    void EnableChaseComponent()
    {
        for (int i = 0; i < ComponentsToEnable.Length; i++)
        {
            ComponentsToEnable[i].enabled = true;
        }
    }
    //void SpawnPlayer()
    //{
        
    //    RandomX = rnd.Next(LowerBoundX, UpperBoundX);
    //    RandomZ = rnd.Next(LowerBoundZ, UpperBoundZ);

    //    Vector3 SpawnPosition = new Vector3(RandomX, SpawnHeight, RandomZ);
    //    Instantiate(Player, SpawnPosition, Quaternion.identity);
    //}
}
