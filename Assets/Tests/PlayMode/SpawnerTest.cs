using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SpawnerTest
{

    [UnityTest]
    public IEnumerator Spawn3Obstacles()
    {
        var obstacle = new GameObject().AddComponent<Obstacle>();
        obstacle.gameObject.AddComponent<BoxCollider2D>();
        obstacle.gameObject.name = "Obstacle";

        var spawner = new GameObject().AddComponent<Spawner>();
        spawner.speed = 5;
        spawner.obstacles = new GameObject[] { obstacle.gameObject };

        obstacle.gameObject.SetActive(false);

        var DeadZone = new GameObject().AddComponent<BoxCollider2D>();
        DeadZone.isTrigger = true;
        DeadZone.name = "DeadZone";
        DeadZone.tag = "DeadZone";
        DeadZone.size = new Vector2(1, 10);
        DeadZone.transform.position = new Vector2(-30, 0);

        Assert.IsTrue(Vector2.Distance(DeadZone.transform.position, spawner.transform.position) > 3);

        yield return new WaitForSeconds(0.1f);

        SpawnAndTest(spawner,1);
        yield return new WaitForSeconds(0.5f);
        SpawnAndTest(spawner, 2);
        yield return new WaitForSeconds(0.5f);
        SpawnAndTest(spawner, 3);

        yield return new WaitForSeconds(30/5);

        int obstacleInstance = GameObject.FindObjectsOfType<Obstacle>().Length;
        Assert.AreEqual(0, obstacleInstance);

    }

    private static void SpawnAndTest(Spawner spawner,int equal)
    {
        spawner.Spawn(0);
        int obstacleInstance = GameObject.FindObjectsOfType<Obstacle>().Length;
        Assert.AreEqual(equal, obstacleInstance);
    }
}
