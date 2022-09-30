using System;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public KeyCode jumpKey;

    public static Action OnDead;

    public float jumpForce = 10;
    public bool grounded;
    void Start()
    {
        grounded = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(jumpKey))
        {
            Jump();
        }
    }

    public void Jump()
    {
        if (!grounded) return;
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            OnDead?.Invoke();
        }
    }
}
