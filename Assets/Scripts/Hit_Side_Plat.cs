using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hit_Side_Plat : MonoBehaviour
{

    private void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.name == "Player")
        {
            SceneManager.LoadScene("Main Scene");
        }
    }

}
