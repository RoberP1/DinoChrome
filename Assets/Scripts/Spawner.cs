using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstacles;
    public float speed = 1;
    public void Spawn(float aceleration)
    {
        int randomNumber = Random.Range(0, obstacles.Length);
        GameObject obstacle = Instantiate(obstacles[randomNumber], transform.position, Quaternion.identity);
        obstacle.GetComponent<Obstacle>().vel = speed;
        speed += aceleration;
    }
}
