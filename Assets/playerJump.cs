using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerJump : MonoBehaviour
{
    private Rigidbody2D rb;

    public float jumpSpeed, xOffset, yOffset, xSize, ySize;
    public bool isGrounded;
    public LayerMask groundMask;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        isGrounded = Physics2D.OverlapBox(new Vector2(transform.position.x + xOffset, transform.position.y + yOffset), new Vector2(xSize, ySize), 0f, groundMask);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);

        }

        playerVariebels.isJumping = !isGrounded;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(new Vector2(transform.position.x + xOffset, transform.position.y + yOffset), new Vector2(xSize, ySize));
    }

}
