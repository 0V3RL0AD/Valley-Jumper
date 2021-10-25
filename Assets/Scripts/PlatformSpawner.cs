using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject[] Platforms;

    private int PickPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider Col)
    {
        if(Col.gameObject.name == "Male_01_V02")
        {
            PickPrefab = Random.Range(0, Platforms.Length);

            Instantiate(Platforms[PickPrefab], new Vector3(transform.position.x + 21, transform.position.y, transform.position.z), Quaternion.identity);
        }
    }
}
