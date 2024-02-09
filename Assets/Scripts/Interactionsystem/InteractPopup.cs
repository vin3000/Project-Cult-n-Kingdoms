using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class InteractPopup : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interaAction;
    public GameObject textPopUp;
    //Appearance related
    float alpha = 0;
    public TextMeshPro TMP;
    //For the non range based ones
    public bool isRangeBased; //is chosen in the editor depending on the object
    bool isTouched; 

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isRangeBased)
        {
            if (isInRange && alpha < 1) //if player is in range
            {
                alpha += 2 * Time.deltaTime;
                TMP.color = new Color(1, 1, 1, alpha);
            }
            if (!isInRange && alpha > 0)
            {
                alpha -= 2 * Time.deltaTime;
                TMP.color = new Color(1, 1, 1, alpha);
            }
        }
        else
        {
            if (isTouched && alpha < 1)
            {
                alpha += 2 * Time.deltaTime;
                TMP.color = new Color(1, 1, 1, alpha);
            }
            if (!isInRange && alpha > 0)
            {
                alpha -= 2 * Time.deltaTime;
                TMP.color = new Color(1, 1, 1, alpha);
            }
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
    public void DoorNotification()
    {
        isTouched = true;
    }
}