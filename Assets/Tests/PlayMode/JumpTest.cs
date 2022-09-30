using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class JumpTest
{

    [UnityTest]
    public IEnumerator JumpTestWithEnumeratorPasses()
    {
        var Ground = new GameObject().AddComponent<BoxCollider2D>();
        Ground.tag = "Ground";
        Ground.name = "Ground";
        Ground.size = new Vector2(10, 1);
        Ground.transform.position = new Vector2(0, -5);
        

        var player = new GameObject().AddComponent<Player>();
        player.gameObject.AddComponent<BoxCollider2D>();
        player.gameObject.name = "Player";
        player.transform.position = new Vector2(0, -4);
        player.jumpForce = 10;

        yield return new WaitForSeconds(1f);
        float playerY = player.transform.position.y;

        player.Jump();
  
        yield return new WaitForSeconds(0.5f);
        
        Assert.IsTrue(player.transform.position.y > playerY);

        float velY = player.GetComponent<Rigidbody2D>().velocity.y;
        player.Jump();
        
        Assert.IsFalse(player.GetComponent<Rigidbody2D>().velocity.y > velY);


    }
}
