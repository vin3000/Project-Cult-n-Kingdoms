using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractPopup : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interaAction;
    public GameObject textPopUp;
    float alpha = 0;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange && alpha < 1) //if player is in range
        {
            alpha += 2 * Time.deltaTime;
            spriteRenderer.color = new Color(1, 1, 1, alpha);
        }
        if (!isInRange && alpha > 0)
        {
            alpha -= 2 * Time.deltaTime;
            spriteRenderer.color = new Color(1, 1, 1, alpha);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("Player now in range of popup");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            Debug.Log("Player now out of range of popup");
        }
    }
}