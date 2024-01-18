using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public bool IsOpen;

    public void OpenDoor(GameObject obj)
    {
        if (!IsOpen)
        {
            PlayerInventory Inventory = obj.GetComponent<PlayerInventory>();
            if (Inventory)
            {
                if (Inventory.DoorKey > 0)
                {
                    IsOpen = true;
                    Inventory.UseKey();
                    Debug.Log("door is unlocked");
                }
            }
        }
        if (IsOpen)
        {
            //Ladda nya scenen, med fadeout animation som Victor fixar
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
