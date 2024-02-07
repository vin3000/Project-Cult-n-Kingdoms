using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermov2 : MonoBehaviour
{
    float h;
    public float speed;
    public AudioClip audioData;
    Rigidbody2D rb;
    //animation stuff dw bout it
    public Animator animator;

    public float jumpForce;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public LayerMask wallLayer;
    bool isGrounded;
    bool jump;


    [Header("Wall jump system")]
    public Transform wallCheck;
    bool isWallTouch;
    bool isSliding;
    public float wallSlidingSpeed;
    public float wallJumpDuration;
    public Vector2 wallJumpForce;
    bool wallJumping;

    private AudioSource GetAudio()
    {
        return GetComponent<AudioSource>();
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        h = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("speed", Mathf.Abs(h));
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true; 
        }
        isGrounded = Physics2D.OverlapBox(groundCheck.position, new Vector2(1.7f, 0.24f), 0, groundLayer);
        isWallTouch = Physics2D.OverlapBox(wallCheck.position, new Vector2(0.2f, 0.9f), 0, wallLayer);

        if(isWallTouch && !isGrounded && h != 0)
        {
            isSliding = true;
        }
        else
        {
            isSliding = false;
        }

        flip();

        if (!playerVariebels.isRunning)
        {
            speed = 8;
            animator.SetBool("IsRunning", false);
        }
        if (playerVariebels.isRunning)
        {
            
            speed = 15;
            animator.SetBool("IsRunning", true);
            
        }


    }
    private void FixedUpdate()
    {
        

        if (jump)
        {
            Jump();
        }

        if (isSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
            //starts sliding animation
            animator.SetBool("isSliding", true);
            animator.SetBool("IsJumping", false);
        }
        else
        {
            animator.SetBool("isSliding", false);
        }

        if (wallJumping)
        {
            rb.velocity = new Vector2(-h * wallJumpForce.x, wallJumpForce.y);
        }
        else
        {
            rb.velocity = new Vector2(h * speed, rb.velocity.y);
            GetComponent<AudioSource>().Play();
        }

        //animator thing
        if (!isGrounded && !isSliding)
        {
            animator.SetBool("IsJumping", true);
        }
        else
        {
            //if player is on floor, stops animation
            animator.SetBool("IsJumping", false);
        }

    }

    void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        else if (isSliding)
        {
            wallJumping = true;
            Invoke("StopWalljump", wallJumpDuration); 
        }

        jump = false;

    }

    void StopWalljump()
    {
        wallJumping = false;
    }

    void flip()
    {
        if (h < -0.01f) transform.localScale = new Vector3(-1, 1, 1);
        if (h > 0.01f) transform.localScale = new Vector3(1, 1, 1);
    }

}
