using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    public bool isPickedUp = false;
    float alpha = 1;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPickedUp && alpha > 0)
        {
            alpha -= 3*Time.deltaTime;
            spriteRenderer.color = new Color (1,1,1,alpha);
        }
    }
    public void KeyInteract()
    {
        isPickedUp = true;
    }
}
