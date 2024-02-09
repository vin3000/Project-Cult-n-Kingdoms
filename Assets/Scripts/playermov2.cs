using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class playermov2 : MonoBehaviour
{
    float h;
    public float speed;
    public AudioSource walkSound;
    public AudioSource runSound;
    public AudioSource jumpSound;
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
            if (runSound.isPlaying)
            {
                walkSound.Stop();
            }
            else if (!runSound.isPlaying && !isSliding)
            {
                runSound.Play();
            }

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
            if (walkSound.isPlaying)
            {
                runSound.Stop();
            } else if (!walkSound.isPlaying && animator.GetFloat("speed") > 0.01 && !isSliding)
            {
                walkSound.Play();
            }
            
        }
        if (rb.velocity == new Vector2(0, 0))
        {
            walkSound.Stop();
            runSound.Stop();
        }

        //animator thing
        if (!isGrounded && !isSliding)
        {
            animator.SetBool("IsJumping", true);
            if (jumpSound.isPlaying)
            {
                return;
            } else
            {
                jumpSound.Play();
            }

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
