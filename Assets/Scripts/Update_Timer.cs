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
        TimerText.text = Time.timeSinceLevelLoad.ToString("F0");
    }
}
