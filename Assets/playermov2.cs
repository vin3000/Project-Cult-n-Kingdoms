using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class playermov2 : MonoBehaviour
{
    float h;
    public float speed;
    Rigidbody2D rb;

    public float jumpForce;
    public Transform groundCheck;
    public LayerMask groundLayer;
    bool isGrounded;
    bool jump;

    [Header("Wall jump system")]
    public Transform wallCheck;
    bool isWallTouch;
    bool isSliding;
    public float wallSlidingSpeed;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true; 
        }
        isGrounded = Physics2D.OverlapBox(groundCheck.position, new Vector2(1.7f, 0.24f), 0, groundLayer);
        isWallTouch = Physics2D.OverlapBox(wallCheck.position, new Vector2(0.1f, 0.9f), 0, groundLayer);

        if(isWallTouch && !isGrounded && h != 0)
        {
            isSliding = true;
        }
        else
        {
            isSliding = false;
        }

        flip();

    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(h * speed, rb.velocity.y);

        if (jump)
        {
            Jump();
        }

        if (isSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }

    }

    void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

        }
        jump = false;
    }

    void flip()
    {
        if (h < -0.01f) transform.localScale = new Vector3(-1, 1, 1);
        if (h > 0.01f) transform.localScale = new Vector3(1, 1, 1);
    }

}
