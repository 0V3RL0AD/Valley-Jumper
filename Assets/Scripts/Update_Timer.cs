using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Update_Timer : MonoBehaviour
{
    public TMP_Text TimerText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Update the Timer text on hud to match the current time that the scene has been loaded for
        TimerText.text = Time.timeSinceLevelLoad.ToString("F0") + " Secs";
    }
}
