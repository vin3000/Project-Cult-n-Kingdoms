using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public GameObject Popup;
    public int DoorKey = 0;
    public int OtherKey = 0;

    public void PickUpDoorKey()
    {
        DoorKey++;

        Debug.Log("Picked up a door key");
    }
    public void PickUpSprintFeature()
    {
        GetComponent<playerSprint>().ActivateSprintFeature();
        Debug.Log("Sending method");
    }
    public void UseKey()
    {
        DoorKey--;
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
