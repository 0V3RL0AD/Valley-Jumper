using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateDistance : MonoBehaviour
{
    public TMP_Text DistanceText;

    public GameObject Player;

    // Update is called once per frame
    void Update()
    {
        //Update the distance text in the hud to match the players current x value, offset by 5 for make up for player starting at -5 x
        DistanceText.text = (Mathf.RoundToInt(Player.transform.position.x) + 5) + " m";
    }

}
