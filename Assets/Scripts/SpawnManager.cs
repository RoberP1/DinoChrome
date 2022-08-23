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

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnCD()
    {
        
        yield return new WaitForSeconds(spawnCD );
        
        
        int s = Random.Range(0, spawners.Length);
        spawners[s].Spawn(Random.Range(0, spawners[s].obstacles.Length),aceleration);
        if (spawnCD > minSpeed) spawnCD -= aceleration;
        StartCoroutine(SpawnCD());
    }
}
