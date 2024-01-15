using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class interactor : MonoBehaviour
{
    public bool IsInRange;
    public KeyCode interactKey;
    public UnityEvent InteraAction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsInRange) //if player is in range
        {
            if (Input.GetKeyDown(interactKey)) //and player presses key
            {
                InteraAction.Invoke(); //Run event
            }
        }
    }
}
