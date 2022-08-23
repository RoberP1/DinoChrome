using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstacles;
    public float speed = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Spawn(int r, float a)
    {
       GameObject obstacle = Instantiate(obstacles[r], transform.position, Quaternion.identity);
       obstacle.GetComponent<Obstacle>().vel = speed;
        speed += a;
    }
}
