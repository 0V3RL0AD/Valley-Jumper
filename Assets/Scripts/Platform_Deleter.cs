using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Deleter : MonoBehaviour
{
    public float PlatformBorn;


    // Start is called before the first frame update
    void Start()
    {
        //when a platform is created, give it a birth time
        PlatformBorn = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //if the platforms life length is over 20 seconds (was born more than 20 seconds ago), then destroy it
        if ((Time.time - PlatformBorn) >= 20)
        {
            Destroy(gameObject);
        }
    }
}
