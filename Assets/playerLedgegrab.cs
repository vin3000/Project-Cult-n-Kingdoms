using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLedgegrab : MonoBehaviour
{
    private bool greenBox, RedBox;
    public float redXOffset, redYOffset, redXSize, redYSize, greenXOffset, greenYOffset, greenXSize, greenYSize;
    private Rigidbody2D rb;
    private float startingGrav;
    public LayerMask groundMask;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startingGrav = rb.gravityScale;
    }

    
    void Update()
    {
        greenBox = Physics2D.OverlapBox(new Vector2(transform.position.x + (greenXOffset * transform.localScale.x), transform.position.y + greenYOffset), new Vector2(greenXSize, greenYSize), 0f, groundMask);
        RedBox = Physics2D.OverlapBox(new Vector2(transform.position.x + (redXOffset * transform.localScale.x), transform.position.y + redYOffset), new Vector2(redXSize, redYSize), 0f, groundMask);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector2(transform.position.x + (redXOffset * transform.localScale.x), transform.position.y + redYOffset), new Vector2(redXSize, redYSize));

    }

}
