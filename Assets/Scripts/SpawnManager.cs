using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Spawner[] spawners;
    public float spawnCD = 1;
    public float aceleration;
    public float minSpeed;
    void Start()
    {
        StartCoroutine(SpawnCD());
    }
    IEnumerator SpawnCD()
    {

        yield return new WaitForSeconds(spawnCD);

        Spawn();
    }

    private void Spawn()
    {
        int randomSpawner = Random.Range(0, spawners.Length);
        spawners[randomSpawner].Spawn(aceleration);
        if (spawnCD > minSpeed) spawnCD -= aceleration;
        StartCoroutine(SpawnCD());
    }
}
