using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    private GameObject Player;
    public GameObject SpawnPoint;
    public GameObject[] AllPlatforms;
    public GameObject[] UpPlatforms;

    private int PickPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.name == "Player" && Player.transform.position.y > 10)
        {
            PickPrefab = Random.Range(0, AllPlatforms.Length);

            Instantiate(AllPlatforms[PickPrefab], new Vector3(SpawnPoint.transform.position.x + 10, SpawnPoint.transform.position.y, SpawnPoint.transform.position.z), Quaternion.identity);
        }
        if (Col.gameObject.name == "Player" && Player.transform.position.y <= 10)
        {
            PickPrefab = Random.Range(0, UpPlatforms.Length);

            Instantiate(UpPlatforms[PickPrefab], new Vector3(SpawnPoint.transform.position.x + 10, SpawnPoint.transform.position.y, SpawnPoint.transform.position.z), Quaternion.identity);
        }
    }
}
