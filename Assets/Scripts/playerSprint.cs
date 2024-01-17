using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSprint : MonoBehaviour
{
    public float totalStamina;
    public float stamina;
    public GameObject staminaBar;
    public bool sprintFeature = false;
    public void ActivateSprintFeature()
    {
        sprintFeature = true;
        Debug.Log("Activating sprint feature");
    }

    void Awake()
    {
        stamina = totalStamina;
    }

    
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift) && stamina > 0 && sprintFeature)
        {
            playerVariebels.isRunning = true;
            stamina -= 0.25f;
        }
        
        else
        {
            playerVariebels.isRunning = false;
        }
        
        if(stamina < 100 && !Input.GetKey(KeyCode.LeftShift))
        {
            stamina += 0.25f;
        }

        if(staminaBar != null)
        {
            staminaBar.transform.localScale = new Vector2(stamina / totalStamina, staminaBar.transform.localScale.y);
        }
    }
}
