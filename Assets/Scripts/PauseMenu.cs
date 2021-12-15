using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour
{

    public AudioSource BGM;

    public static bool isGamePaused = false;

    public GameObject PauseMenuUi;
    public GameObject HUD;

    public void Start()
    {
        //reset variables to start values
        PauseMenuUi.SetActive(false);
        HUD.SetActive(true);
        Time.timeScale = 1f;
        isGamePaused = false;
        Debug.Log("Start");
    }


    public void Resume()
    {
        //Switch from pause menu to hud, set game timescale back to 1, unpause bgm
        PauseMenuUi.SetActive(false);
        HUD.SetActive(true);
        Time.timeScale = 1f;
        BGM.UnPause();
        isGamePaused = false;
        Debug.Log("resumed");
    }

    public void Pause()
    {
        //Switch from hud to pause menu, set game timescale to 0 (freeze time), pause bgm
        PauseMenuUi.SetActive(true);
        HUD.SetActive(false);
        Time.timeScale = 0f;
        BGM.Pause();
        isGamePaused = true;
        Debug.Log("paused");
    }



    //Restart the run - loads Main Scene(game scene)
    public void RestartRun()
    {
        PauseMenuUi.SetActive(false);
        HUD.SetActive(true);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Scene");
    }

    //load Menu Scene
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }



}
