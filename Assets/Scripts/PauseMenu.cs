using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour
{
    

    public static bool isGamePaused = false;

    public GameObject PauseMenuUi;
    public GameObject HUD;


    public void Resume()
    {
        PauseMenuUi.SetActive(false);
        HUD.SetActive(true);
        Time.timeScale = 1f;
        
        isGamePaused = false;
        Debug.Log("resumed");
    }

    public void Pause()
    {
        PauseMenuUi.SetActive(true);
        HUD.SetActive(false);
        Time.timeScale = 0f;
        
        isGamePaused = true;
        Debug.Log("paused");
    }



    //Restart the run - loads Main Scene(game scene)
    public void RestartRun()
    {
        SceneManager.LoadScene("Main Scene");
    }

    //load Menu Scene
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }



}
