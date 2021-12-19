using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    void Start()
    {
        Application.targetFrameRate = 15;
    }
        public void PlayGame()
    {
        SceneManager.LoadScene("Main Scene");
    }

    

}
