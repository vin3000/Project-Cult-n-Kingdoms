using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainscene : MonoBehaviour
{
    public void PlayGame() 
    {
        SceneManager.LoadSceneAsync(1);
        new WaitForSeconds(5);
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
