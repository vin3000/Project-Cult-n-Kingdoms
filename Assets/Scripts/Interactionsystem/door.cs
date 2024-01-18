using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour
{
    public bool IsOpen;
    public GameObject sceneChanger;
    float countdown = 3;
    bool StartCountdown = false;
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
                    StartCountdown = true;
                }
            }
        }
        if (IsOpen && countdown<=0)
        {
            sceneChanger.GetComponent<SceneChanger>().FadeToScene();
            Invoke("LoadScene", 1.5f);
        }
    }
    public void LoadScene()
    {
        SceneManager.LoadSceneAsync(2);
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (StartCountdown && countdown > 0)
        {
            countdown -= Time.deltaTime;
        }
    }
}
