using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class settignsforuse : MonoBehaviour
{
    public GameObject settingsmenu;
    public GameObject MainMenu;
    public AudioSource backgroundMusic;
    public bool backgroundMusicActive = true;

    public void SwitchToPlayScene()
    {
        SceneManager.LoadScene(sceneName: "GameScreen");
    }
    // Start is called before the first frame update
    void Start()
    {
        backgroundMusicActive = true;
        backgroundMusic.Play();
    }
    public void SettingButton()
    {
        MainMenu.SetActive(false);
        settingsmenu.SetActive(true);
    }
    public void MenuBackButton()
    {
        MainMenu.SetActive(true);
        settingsmenu.SetActive(false);
    }
    public void MusicButton()
    {
        if (backgroundMusicActive)
        {
            backgroundMusic.Stop();
            backgroundMusicActive = false;
        }
        else
        {
            backgroundMusic.Play();
            backgroundMusicActive = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
