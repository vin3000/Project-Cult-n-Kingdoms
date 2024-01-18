using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainscene : MonoBehaviour
{
    public GameObject sceneChanger;

    public void PlayGame() 
    {
        sceneChanger.GetComponent<SceneChanger>().FadeToScene();
        Invoke("LoadScene", 1.5f);

    }
    public void LoadScene()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void Endgame()
    {
        Application.Quit();
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
