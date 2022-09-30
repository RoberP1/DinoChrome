using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SpawnTest
{

    [UnityTest]
    public IEnumerator SpawnRandom()
    {
        var obstacle = new GameObject().AddComponent<Obstacle>();
        obstacle.gameObject.AddComponent<BoxCollider2D>();
        obstacle.gameObject.name = "Obstacle";

        var spawner = new GameObject().AddComponent<Spawner>();
        spawner.speed = 5;
        spawner.obstacles = new GameObject[] { obstacle.gameObject };

        obstacle.gameObject.SetActive(false);

        int randomNumber = Random.Range(1, 6);
        
        for (int i = 0; i < randomNumber; i++)
        {
            spawner.Spawn(0);
        }

        Assert.AreEqual(randomNumber, GameObject.FindObjectsOfType<Obstacle>().Length);

        yield return null;

    }

}
