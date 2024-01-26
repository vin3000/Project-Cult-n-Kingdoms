using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public bool isOpen;
    public GameObject sceneChanger;
    float countdown = 1;
    bool startCountdown = false;
    public void OpenDoor(GameObject obj)
    {
        if (!isOpen)
        {
            PlayerInventory Inventory = obj.GetComponent<PlayerInventory>();
            if (Inventory)
            {
                if (Inventory.doorKey > 0)
                {
                    isOpen = true;
                    Inventory.UseKey();
                    Debug.Log("Door is unlocked.");
                    startCountdown = true;
                }
            }
        }
        if (isOpen && countdown<=0)
        {
            sceneChanger.GetComponent<SceneChanger>().FadeToScene();
            Invoke(nameof(LoadScene), 1.5f);
        }
    }
    public void LoadScene()
    {
        SceneManager.LoadSceneAsync(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (startCountdown && countdown > 0)
        {
            countdown -= Time.deltaTime;
        }
    }
}
