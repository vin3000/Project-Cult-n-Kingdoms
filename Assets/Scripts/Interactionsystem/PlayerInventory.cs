using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public GameObject Popup;
    public int doorKey = 0;
    public int otherKey = 0;

    public void PickUpDoorKey()
    {
        doorKey++;

        Debug.Log("Picked up a door key");
    }
    public void PickUpSprintFeature()
    {
        GetComponent<PlayerSprint>().ActivateSprintFeature();
        Debug.Log("Sending method");
    }
    public void UseKey()
    {
        doorKey--;
        Debug.Log("Used Doorkey");
    }
    public void NotifyPlayer()
    {
        Popup.SetActive(true);
    }
    public void DeNotifyPlayer()
    {
        Popup.SetActive(false);
    }
}
