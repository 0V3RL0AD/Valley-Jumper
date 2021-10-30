using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Deleter : MonoBehaviour
{
    public float PlatformBorn;


    // Start is called before the first frame update
    void Start()
    {
        PlatformBorn = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Time.time - PlatformBorn) >= 20)
        {
            Destroy(gameObject);
        }
    }
}
