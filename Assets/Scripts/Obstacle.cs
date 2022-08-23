using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float vel;
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-vel, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DeadZone")
        {
            Destroy(gameObject);
        }
    }
}
