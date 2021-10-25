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
        DistanceText.text = Mathf.RoundToInt(Player.transform.position.x) + " m";
    }

}
