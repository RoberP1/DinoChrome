using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public KeyCode jumpKey;

    public static Action OnDead;

    [SerializeField] float jumpForce = 10;
    [SerializeField] private LayerMask ground;
    [SerializeField] private bool grounded;
    void Start()
    {
        grounded = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(jumpKey)&& grounded)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            grounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            OnDead?.Invoke();
        }
    }
}
