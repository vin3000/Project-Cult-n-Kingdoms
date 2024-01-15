using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class playerWalk : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveInputH;
    public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {

        if (!playerVariebels.isRunning)
        {
            speed = 8;
        }
        if (playerVariebels.isRunning)
        {
            speed = 15;
        }

        


            moveInputH = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(moveInputH * speed, rb.velocity.y);

            if (moveInputH != 0)
            {

                playerVariebels.isWalking = true;

            }
            else
            {
                playerVariebels.isWalking = false;
            }
        
       



    }

     

}
