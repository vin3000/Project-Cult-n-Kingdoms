using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class dialoguecode : MonoBehaviour
{
    public TextMeshProUGUI textcomponent;
    public string[] lines;
    public float textspeed;
    //hur den skriver ut dialoguen och hastigheten på den

    private int Index;

    // Start is called before the first frame update
    void Start()
    {
        textcomponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textcomponent.text == lines[Index])
            {
                NextLine();
                
            }
            else
            {
                StopAllCoroutines();
                textcomponent.text = lines[Index];
            }
        }
    }
    void StartDialogue()
    {
        Index = 0;
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine()
    {
        foreach (char c in lines[Index].ToCharArray()) 
        {
            textcomponent.text += c;
            yield return new WaitForSeconds(textspeed);

        } 
    }
    void NextLine()
    {
        if (Index < lines.Length - 1)
        {
            Index++;
            textcomponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }

    }


}
