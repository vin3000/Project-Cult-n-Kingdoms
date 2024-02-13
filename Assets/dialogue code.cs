using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class dialoguecode : MonoBehaviour
{
    public TextMeshProUGUI textcomponent;
    public string[] lines;
    public float textspeed;
    //hur den skriver ut dialoguen och hastigheten p� den

    private int Index;

    public GameObject sceneChanger; //Objekt f�r scene fade
    private int dialougeSkips;   //R�knar hur m�nga dialoger som har varit


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
                Debug.Log("End of line");
                dialougeSkips += 1;
                Debug.Log("dialougeSkips = " + dialougeSkips);
            }
            else
            {
                StopAllCoroutines();
                textcomponent.text = lines[Index];
                
            }
        }
        if (dialougeSkips == 6) //n�r man sett alla dialoger
        {
            sceneChanger.GetComponent<SceneChanger>().FadeToScene(); //fade
            Invoke(nameof(LoadScene), 1.5f);
        }
    }

    public void LoadScene() //laddar startscenen
    {
        SceneManager.LoadSceneAsync(0);
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
