using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SETTINGS : MonoBehaviour
{
    public GameObject settingsmenu;
    public Text MusicOn;
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
            MusicOn.text = "music:Off";
            backgroundMusicActive = false;
        }else
        {
            backgroundMusic.Play();
            MusicOn.text = "Music: On";
            backgroundMusicActive = true;
        }
    }
     
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
